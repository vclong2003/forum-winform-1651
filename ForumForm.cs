using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    public partial class ForumForm : Form
    {
        private List<Subforum> subforums;
        private Subforum selectedSubforum;

        private List<Thread> threads;
        private Thread selectedThread;

        private List<Post> posts;
        private Post selectedPost;
        public ForumForm()
        {
            InitializeComponent();
            addSubforumGroup.Visible = false;
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
        private void ForumForm_Load(object sender, EventArgs e)
        {
            addSubforumGroup.Visible = Program.moderatorMode;
            LoadSubforum();
        }
        private void LoadSubforum()
        {
            Loading(true);
            var collection = DBHandler.Instance.Database.GetCollection<Subforum>("Subforum");
            var filter = Builders<Subforum>.Filter.Empty;

            subforums = collection.Find(filter).ToList();

            subforumListbox.BeginUpdate();
            subforumListbox.DataSource = subforums;
            subforumListbox.DisplayMember = "Title";
            subforumListbox.EndUpdate();

            Loading(false);
            return;
        }
        private void LoadThread()
        {
            Loading(true);
            var collection = DBHandler.Instance.Database.GetCollection<Thread>("Thread");
            var filter = Builders<Thread>.Filter.Eq(t => t.Subforum, selectedSubforum);

            threads = collection.Find(filter).ToList();

            threadListbox.BeginUpdate();
            threadListbox.DataSource = threads;
            threadListbox.DisplayMember = "Title";
            threadListbox.EndUpdate();

            Loading(false);
            return;
        }
        private void LoadPost()
        {
            Loading(true);
            var collection = DBHandler.Instance.Database.GetCollection<Post>("Post");
            var filter = Builders<Post>.Filter.Eq(p => p.Thread, selectedThread);

            posts = collection.Find(filter).ToList();

            postListBox.BeginUpdate();
            postListBox.DataSource = posts;
            postListBox.DisplayMember = "Content";
            postListBox.EndUpdate();

            Loading(false);
            return;
        }
        private void ForumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void addSubforumBtn_Click(object sender, EventArgs e)
        {
            if (addSubforumTextbox.Text == "")
            {
                MessageBox.Show("Please enter title");
                return;
            }

            ((Moderator)Program.currentUser).CreateSubforum(addSubforumTextbox.Text);
            LoadSubforum();
            return;
        }


        private void subforumListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubforum = subforums[subforumListbox.SelectedIndex];
            LoadThread();
            Debug.WriteLine(selectedSubforum.Title);
        }

        private void addThreadBtn_Click(object sender, EventArgs e)
        {
            if (addThreadInput.Text == "")
            {
                MessageBox.Show("Please enter title!");
                return;
            }

            Program.currentUser.CreateThread(selectedSubforum, addThreadInput.Text);
            LoadThread();
            return;
        }

        private void addPostBtn_Click(object sender, EventArgs e)
        {
            if (addPostTextBox.Text == "")
            {
                MessageBox.Show("Please enter content!");
                return;
            }

            Program.currentUser.AddPost(selectedThread, addPostTextBox.Text);
            LoadPost();
            return;

        }

        private void threadListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedThread = threads[threadListbox.SelectedIndex];
            LoadPost();
        }

        private void postListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPost = posts[postListBox.SelectedIndex];
            if (selectedPost.Creator.Id == Program.currentUser.Id)
            {
                addPostTextBox.Text = selectedPost.Content;
            }
        }
    }
}
