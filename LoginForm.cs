﻿namespace VCLForum
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.participantBtn.Checked = true;
        }

        private void registerText_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.registerForm.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.emailInput.Text == "" || this.pwdInput.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            bool loginState = false;

            if (participantBtn.Checked)
            {
                loginState = User.Login<Participant>(this.emailInput.Text, this.pwdInput.Text);
            }
            else if (moderatorBtn.Checked)
            {
                loginState = User.Login<Moderator>(this.emailInput.Text, this.pwdInput.Text);
            }

            if (loginState == false)
            {
                MessageBox.Show("Try again!");
                this.Cursor = Cursors.Default;
                return;
            }

            this.Hide();
            Program.forumForm.Show();
            return;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
