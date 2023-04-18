﻿namespace VCLForum
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginText_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.loginForm.Show();
        }

        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (emailInput.Text == "" || nameInput.Text == "" || pwdInput.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            Cursor = Cursors.WaitCursor;

            bool registerState = Participant.Register(nameInput.Text, emailInput.Text, pwdInput.Text);

            Cursor = Cursors.Default;

            if (registerState == false)
            {
                MessageBox.Show("An error occurred!");
                return;
            }

            Hide();
            Program.loginForm.Show();
            return;
        }
    }
}
