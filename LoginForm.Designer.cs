namespace VCLForum
{
    partial class LoginForm
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
            submitBtn = new Button();
            pwdInput = new TextBox();
            emailInput = new TextBox();
            label2 = new Label();
            label3 = new Label();
            registerText = new Label();
            participantBtn = new RadioButton();
            moderatorBtn = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 144);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 0;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(348, 232);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(94, 29);
            submitBtn.TabIndex = 9;
            submitBtn.Text = "Login";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += submitBtn_Click;
            // 
            // pwdInput
            // 
            pwdInput.Location = new Point(291, 157);
            pwdInput.Name = "pwdInput";
            pwdInput.Size = new Size(215, 27);
            pwdInput.TabIndex = 8;
            // 
            // emailInput
            // 
            emailInput.Location = new Point(291, 117);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(215, 27);
            emailInput.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 160);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(233, 120);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 5;
            label3.Text = "Email";
            // 
            // registerText
            // 
            registerText.AutoSize = true;
            registerText.Location = new Point(315, 411);
            registerText.Name = "registerText";
            registerText.Size = new Size(160, 20);
            registerText.TabIndex = 10;
            registerText.Text = "Or, create new account";
            registerText.Click += registerText_Click;
            // 
            // participantBtn
            // 
            participantBtn.AutoSize = true;
            participantBtn.Location = new Point(299, 190);
            participantBtn.Name = "participantBtn";
            participantBtn.Size = new Size(100, 24);
            participantBtn.TabIndex = 11;
            participantBtn.TabStop = true;
            participantBtn.Text = "Participant";
            participantBtn.UseVisualStyleBackColor = true;
            // 
            // moderatorBtn
            // 
            moderatorBtn.AutoSize = true;
            moderatorBtn.Location = new Point(405, 190);
            moderatorBtn.Name = "moderatorBtn";
            moderatorBtn.Size = new Size(101, 24);
            moderatorBtn.TabIndex = 12;
            moderatorBtn.TabStop = true;
            moderatorBtn.Text = "Moderator";
            moderatorBtn.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(moderatorBtn);
            Controls.Add(participantBtn);
            Controls.Add(registerText);
            Controls.Add(submitBtn);
            Controls.Add(pwdInput);
            Controls.Add(emailInput);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button submitBtn;
        private TextBox pwdInput;
        private TextBox emailInput;
        private Label label2;
        private Label label3;
        private Label registerText;
        private RadioButton participantBtn;
        private RadioButton moderatorBtn;
    }
}