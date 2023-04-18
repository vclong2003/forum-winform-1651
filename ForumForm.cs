namespace VCLForum
{
    public partial class ForumForm : Form
    {
        public ForumForm()
        {
            InitializeComponent();
        }

        private void ForumForm_Load(object sender, EventArgs e)
        {

        }

        private void ForumForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
