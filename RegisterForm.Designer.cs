namespace VCLForum
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            emailInput = new TextBox();
            pwdInput = new TextBox();
            submitBtn = new Button();
            loginText = new Label();
            label3 = new Label();
            nameInput = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(246, 137);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(222, 177);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Password";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(304, 134);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(213, 27);
            emailInput.TabIndex = 2;
            // 
            // pwdInput
            // 
            pwdInput.Location = new Point(304, 174);
            pwdInput.Name = "pwdInput";
            pwdInput.Size = new Size(213, 27);
            pwdInput.TabIndex = 3;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(304, 234);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(210, 29);
            submitBtn.TabIndex = 4;
            submitBtn.Text = "Register as participant";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += submitBtn_Click;
            // 
            // loginText
            // 
            loginText.AutoSize = true;
            loginText.Location = new Point(368, 387);
            loginText.Name = "loginText";
            loginText.Size = new Size(46, 20);
            loginText.TabIndex = 5;
            loginText.Text = "Login";
            loginText.Click += loginText_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 98);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 6;
            label3.Text = "Name";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(304, 95);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(213, 27);
            nameInput.TabIndex = 7;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(nameInput);
            Controls.Add(label3);
            Controls.Add(loginText);
            Controls.Add(submitBtn);
            Controls.Add(pwdInput);
            Controls.Add(emailInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VCLForum Register";
            FormClosing += RegisterForm_FormClosing;
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox emailInput;
        private TextBox pwdInput;
        private Button submitBtn;
        private Label loginText;
        private Label label3;
        private TextBox nameInput;
    }
}