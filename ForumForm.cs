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
        private void LoadSubforum()
        {
            var collection = DBHandler.Instance.Database.GetCollection<Subforum>("Subforum");
            var filter = Builders<Subforum>.Filter.Empty;

            subforums = collection.Find(filter).ToList();

            subforumListbox.BeginUpdate();
            subforumListbox.DataSource = subforums;
            subforumListbox.DisplayMember = "Title";
            subforumListbox.EndUpdate();

            return;
        }
        private void LoadThread()
        {
            var collection = DBHandler.Instance.Database.GetCollection<Thread>("Thread");
            var filter = Builders<Thread>.Filter.Eq(t => t.Subforum, selectedSubforum);

            threads = collection.Find(filter).ToList();

            threadListbox.BeginUpdate();
            threadListbox.DataSource = threads;
            threadListbox.DisplayMember = "Title";
            threadListbox.EndUpdate();

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
    }
}
