using MongoDB.Driver;

namespace VCLForum
{
    public partial class ForumForm : Form
    {
        private Panel selectedSubforumPanel;
        private Subforum selectedSubforum;

        private Panel selectedThreadPanel;
        private Thread selectedThread;

        private Post selectedPost;
        public ForumForm()
        {
            InitializeComponent();
            addSubforumGroup.Visible = false;
        }
        private void ForumForm_Load(object sender, EventArgs e)
        {
            addSubforumGroup.Visible = Program.moderatorMode;
            LoadSubforum();
        }
        private void Loading(bool isLoading)
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
            var collection = DBHandler.Instance.Database.GetCollection<Subforum>("Subforum");
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
            var collection = DBHandler.Instance.Database.GetCollection<Thread>("Thread");
            var filter = Builders<Thread>.Filter.Eq(t => t.Subforum, selectedSubforum);
            var sort = Builders<Thread>.Sort.Descending(t => t.CreatedAt);

            postPanel.Controls.Clear();
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
            var collection = DBHandler.Instance.Database.GetCollection<Post>("Post");
            var filter = Builders<Post>.Filter.Eq(p => p.Thread, selectedThread);
            var sort = Builders<Post>.Sort.Descending(p => p.PostDate);

            postPanel.Controls.Clear();
            collection.Find(filter).Sort(sort).ToList().ForEach(p =>
            {
                postPanel.Controls.Add(PostItem(p));
            });

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

            }

            return panel;
        }


        //Add Subforum
        private void addSubforumBtn_Click(object sender, EventArgs e)
        {
            if (addSubforumTextbox.Text == "")
            {
                MessageBox.Show("Please enter title");
                return;
            }

            var newSubforum = ((Moderator)Program.currentUser).CreateSubforum(addSubforumTextbox.Text);
            if (newSubforum != null)
            {
                var subforumItem = SubforumItem(newSubforum);
                subforumPanel.Controls.Add(subforumItem);
                subforumPanel.Controls.SetChildIndex(subforumItem, 0);
            }

            return;
        }

        // Add Thread
        private void addThreadBtn_Click(object sender, EventArgs e)
        {
            if (addThreadInput.Text == "")
            {
                MessageBox.Show("Please enter title!");
                return;
            }

            var newThread = Program.currentUser.CreateThread(selectedSubforum, addThreadInput.Text);
            if (newThread != null)
            {
                var threadItem = ThreadItem(newThread);
                threadPanel.Controls.Add(threadItem);
                threadPanel.Controls.SetChildIndex(threadItem, 0);
            }

            return;
        }

        // Add Post
        private void addPostBtn_Click(object sender, EventArgs e)
        {
            if (addPostTextBox.Text == "")
            {
                MessageBox.Show("Please enter content!");
                return;
            }

            var newPost = Program.currentUser.AddPost(selectedThread, addPostTextBox.Text);

            if (newPost != null)
            {
                var postItem = PostItem(newPost);
                postPanel.Controls.Add(postItem);
                postPanel.Controls.SetChildIndex(postItem, 0);
            }

            return;

        }

        private void editPostBtn_Click(object sender, EventArgs e)
        {

        }

        private void ForumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
