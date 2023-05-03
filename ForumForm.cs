using MongoDB.Driver;

namespace VCLForum
{
    public partial class ForumForm : Form
    {
        private Panel? selectedSubforumPanel;
        private Subforum? selectedSubforum;

        private Panel? selectedThreadPanel;
        private Thread? selectedThread;

        private Panel? selectedPostPanel;
        private Post? selectedPost;

        private CancellationTokenSource postsListenerCancelationTokenSource;

        public ForumForm()
        {
            InitializeComponent();
            addSubforumGroup.Visible = false;
            postsListenerCancelationTokenSource = new CancellationTokenSource();
        }
        private void ForumForm_Load(object sender, EventArgs e)
        {
            addSubforumGroup.Visible = Program.moderatorMode;
            this.Text += " - Logged in as " + Program.currentUser.Name;
            LoadSubforum();
        }

        private void Loading(bool isLoading) // Loading cursor
        {
            if (isLoading)
            {
                Cursor = Cursors.WaitCursor;
                return;
            }

            Cursor = Cursors.Default;
            return;
        }
        private void LoadSubforum()
        {
            Loading(true);
            var collection = DBHandler.GetInstance().Database.GetCollection<Subforum>(typeof(Subforum).Name);
            var filter = Builders<Subforum>.Filter.Empty;

            subforumPanel.Controls.Clear();
            collection.Find(filter).ToList().ForEach(s =>
            {
                subforumPanel.Controls.Add(SubforumItem(s));
            });

            Loading(false);
            return;
        }
        private void LoadThread()
        {
            Loading(true);
            var collection = DBHandler.GetInstance().Database.GetCollection<Thread>(typeof(Thread).Name);
            var filter = Builders<Thread>.Filter.Eq(t => t.Subforum, selectedSubforum);
            var sort = Builders<Thread>.Sort.Descending(t => t.CreatedAt);

            ClearPostPanel();
            threadPanel.Controls.Clear();
            collection.Find(filter).Sort(sort).ToList().ForEach(t =>
            {
                threadPanel.Controls.Add(ThreadItem(t));
            });

            Loading(false);
            return;
        }
        private void LoadPost()
        {
            Loading(true);

            var collection = DBHandler.GetInstance().Database.GetCollection<Post>(typeof(Post).Name);
            var filter = Builders<Post>.Filter.Eq(p => p.Thread, selectedThread);
            var sort = Builders<Post>.Sort.Descending(p => p.PostDate);

            ClearPostPanel();
            collection.Find(filter).Sort(sort).ToList().ForEach(p =>
            {
                postPanel.Controls.Add(PostItem(p));
            });

            postsListenerCancelationTokenSource.Cancel();
            postsListenerCancelationTokenSource = new CancellationTokenSource();
            Task.Run(() => WatchForPostChanges(postsListenerCancelationTokenSource.Token));

            Loading(false);
            return;
        }

        private Panel SubforumItem(Subforum s)
        {
            var panel = new Panel();
            var creator = new Label();
            var title = new Label();

            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(creator);
            panel.Controls.Add(title);
            panel.Cursor = Cursors.Hand;
            panel.Location = new Point(3, 3);
            panel.Size = new Size(220, 70);
            panel.TabIndex = 1;

            creator.AutoSize = true;
            creator.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            creator.Location = new Point(3, 48);
            creator.Size = new Size(41, 17);
            creator.TabIndex = 1;
            creator.Text = "Created by: " + s.Creator.Name;

            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            title.Location = new Point(3, 7);
            title.Size = new Size(55, 23);
            title.TabIndex = 0;
            title.Text = s.Title;

            void HandleClick(object sender, EventArgs e)
            {
                selectedSubforum = s;

                if (selectedSubforumPanel != null) selectedSubforumPanel.BackColor = Color.White;
                selectedSubforumPanel = panel;
                selectedSubforumPanel.BackColor = Color.Gainsboro;

                LoadThread();
            }

            panel.Click += HandleClick;
            title.Click += HandleClick;
            creator.Click += HandleClick;

            return panel;
        }
        private Panel ThreadItem(Thread t)
        {
            var panel = new Panel();
            var title = new Label();
            var creator = new Label();

            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(title);
            panel.Controls.Add(creator);
            panel.Cursor = Cursors.Hand;
            panel.Location = new Point(280, 38);
            panel.Size = new Size(305, 85);
            panel.TabIndex = 0;

            title.AutoSize = false;
            title.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            title.Location = new Point(11, 9);
            title.Width = panel.Width - 20;
            title.Height = 50;
            title.TabIndex = 0;
            title.Text = t.Title;

            creator.AutoSize = true;
            creator.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            creator.Location = new Point(11, 58);
            creator.Size = new Size(41, 17);
            creator.TabIndex = 1;
            creator.Text = t.Creator.Name + " at " + t.CreatedAt.ToString();

            void HandleClick(object sender, EventArgs e)
            {
                selectedThread = t;

                if (selectedThreadPanel != null) selectedThreadPanel.BackColor = Color.White;
                selectedThreadPanel = panel;
                selectedThreadPanel.BackColor = Color.Gainsboro;

                LoadPost();
            }

            panel.Click += HandleClick;
            title.Click += HandleClick;
            creator.Click += HandleClick;

            return panel;
        }
        private Panel PostItem(Post p)
        {
            var panel = new Panel();
            var creator = new Label();
            var content = new Label();

            panel.AutoSize = true;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Controls.Add(content);
            panel.Controls.Add(creator);
            panel.Cursor = Cursors.Hand;
            panel.Location = new Point(3, 3);
            panel.MinimumSize = new Size(452, 0);
            panel.TabIndex = 0;
            panel.Padding = new Padding(0, 0, 0, 10);

            creator.AutoSize = true;
            creator.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point);
            creator.Location = new Point(3, 0);
            creator.Size = new Size(41, 17);
            creator.TabIndex = 0;
            creator.Text = p.Creator.Name + " at " + p.PostDate;

            content.AutoSize = true;
            content.Location = new Point(3, 32);
            content.MaximumSize = new Size(panel.Width - 10, 0);
            content.TabIndex = 1;
            content.Text = p.Content;

            void HandleClick(object sender, EventArgs e)
            {
                if (p.Creator.Id != Program.currentUser.Id) return;

                selectedPost = p;
                if (selectedPostPanel != null) selectedPostPanel.BackColor = Color.White;
                selectedPostPanel = panel;
                selectedPostPanel.BackColor = Color.Gainsboro;

                addPostTextBox.Text = p.Content;

                return;
            }

            panel.Click += HandleClick;
            creator.Click += HandleClick;
            content.Click += HandleClick;

            return panel;
        }

        private void AddSubforumToPanel(Subforum s)
        {
            var subforumItem = SubforumItem(s);
            subforumPanel.Controls.Add(subforumItem);
            subforumPanel.Controls.SetChildIndex(subforumItem, 0);
        }
        private void AddThreadToPanel(Thread t)
        {
            var threadItem = ThreadItem(t);
            threadPanel.Controls.Add(threadItem);
            threadPanel.Controls.SetChildIndex(threadItem, 0);
        }
        private void AddPostToPanel(Post p)
        {
            var postItem = PostItem(p);
            postPanel.Controls.Add(postItem);
            postPanel.Controls.SetChildIndex(postItem, 0);
        }

        // Clear the posts in UI
        private void ClearPostPanel()
        {
            selectedPostPanel = null;
            selectedPost = null;
            postPanel.Controls.Clear();
            addPostTextBox.Clear();
        }

        // Add Subforum
        private void addSubforumBtn_Click(object sender, EventArgs e)
        {
            if (addSubforumTextbox.Text == "")
            {
                MessageBox.Show("Please enter title");
                return;
            }

            var newSubforum = ((Moderator)Program.currentUser).CreateSubforum(addSubforumTextbox.Text);
            if (newSubforum == null) return;

            AddSubforumToPanel(newSubforum);
            addSubforumTextbox.Clear();

            return;
        }

        // Add Thread
        private void addThreadBtn_Click(object sender, EventArgs e)
        {
            if (selectedSubforum == null) return;
            if (addThreadInput.Text == "")
            {
                MessageBox.Show("Please enter title!");
                return;
            }

            var newThread = Program.currentUser.CreateThread(selectedSubforum, addThreadInput.Text);
            if (newThread == null) return;

            AddThreadToPanel(newThread);
            addThreadInput.Clear();

            return;
        }

        // Add Post
        private void addPostBtn_Click(object sender, EventArgs e)
        {
            if (selectedThread == null) return;
            if (addPostTextBox.Text == "")
            {
                MessageBox.Show("Please enter content!");
                return;
            }

            Loading(true);
            var newPost = Program.currentUser.AddPost(selectedThread, addPostTextBox.Text);
            Loading(false);
            if (newPost == null) return;

            AddPostToPanel(newPost);
            addPostTextBox.Clear();

            return;
        }

        // Edit post
        private void editPostBtn_Click(object sender, EventArgs e)
        {
            if (selectedPost == null) return;

            Loading(true);
            var editedPost = Program.currentUser.EditPost(selectedPost, addPostTextBox.Text);
            Loading(false);

            var editedPostItem = PostItem(editedPost);
            int index = postPanel.Controls.IndexOf(selectedPostPanel);
            postPanel.Controls.RemoveAt(index);
            postPanel.Controls.Add(editedPostItem);
            postPanel.Controls.SetChildIndex(editedPostItem, index);
            addPostTextBox.Clear();
        }

        // Listen for Post collection in DB
        private void WatchForPostChanges(CancellationToken cancelToken)
        {
            var collection = DBHandler.GetInstance().Database.GetCollection<Post>(typeof(Post).Name);
            var options = new ChangeStreamOptions { FullDocument = ChangeStreamFullDocumentOption.UpdateLookup };
            var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<Post>>()
               .Match(change => change.OperationType == ChangeStreamOperationType.Insert && change.FullDocument.Thread == selectedThread);
            var cursor = collection.Watch(pipeline, options);

            while (true)
            {
                if (cursor.MoveNext())
                {
                    foreach (var change in cursor.ToEnumerable())
                    {
                        if (cancelToken.IsCancellationRequested) return;
                        var newPost = change.FullDocument;
                        if (newPost.Creator.Id != Program.currentUser.Id)
                        {
                            this.Invoke((MethodInvoker)delegate { AddPostToPanel(newPost); });
                        }
                    }
                }
            }
        }

        // Reload
        private void reloadBtn_Click(object sender, EventArgs e)
        {
            selectedThread = null;
            selectedThreadPanel = null;
            ClearPostPanel();
            LoadThread();
        }

        private void ForumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBHandler.CloseConnection();
            Environment.Exit(0);
        }
    }
}
