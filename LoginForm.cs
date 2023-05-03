namespace VCLForum
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            participantBtn.Checked = true;

            //emailInput.Text = "vclong2003@gmail.com";
            //pwdInput.Text = "1234";
        }

        private void registerText_Click(object sender, EventArgs e)
        {
            Hide();
            Program.registerForm.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "" || pwdInput.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            Cursor = Cursors.WaitCursor;

            bool loginState = false;

            if (participantBtn.Checked)
            {
                loginState = User.Login<Participant>(emailInput.Text, pwdInput.Text);
            }
            else if (moderatorBtn.Checked)
            {
                loginState = User.Login<Moderator>(emailInput.Text, pwdInput.Text);
            }

            Cursor = Cursors.Default;

            if (loginState == false)
            {
                MessageBox.Show("Try again!");
                return;
            }

            Hide();
            Program.forumForm.Show();
            return;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBHandler.CloseConnection();
            Environment.Exit(0);
        }
    }
}
