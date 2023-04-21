namespace VCLForum
{
    partial class ForumForm
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
            addSubforumBtn = new Button();
            addSubforumTextbox = new TextBox();
            addSubforumGroup = new GroupBox();
            groupBox1 = new GroupBox();
            addThreadInput = new TextBox();
            addThreadBtn = new Button();
            addPostTextBox = new RichTextBox();
            addPostBtn = new Button();
            editPostBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            subforumPanel = new FlowLayoutPanel();
            threadPanel = new FlowLayoutPanel();
            postPanel = new FlowLayoutPanel();
            reloadBtn = new Button();
            addSubforumGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // addSubforumBtn
            // 
            addSubforumBtn.Location = new Point(160, 26);
            addSubforumBtn.Name = "addSubforumBtn";
            addSubforumBtn.Size = new Size(83, 29);
            addSubforumBtn.TabIndex = 1;
            addSubforumBtn.Text = "Add";
            addSubforumBtn.UseVisualStyleBackColor = true;
            addSubforumBtn.Click += addSubforumBtn_Click;
            // 
            // addSubforumTextbox
            // 
            addSubforumTextbox.Location = new Point(11, 26);
            addSubforumTextbox.Name = "addSubforumTextbox";
            addSubforumTextbox.Size = new Size(143, 27);
            addSubforumTextbox.TabIndex = 3;
            // 
            // addSubforumGroup
            // 
            addSubforumGroup.Controls.Add(addSubforumTextbox);
            addSubforumGroup.Controls.Add(addSubforumBtn);
            addSubforumGroup.Location = new Point(12, 442);
            addSubforumGroup.Name = "addSubforumGroup";
            addSubforumGroup.Size = new Size(253, 70);
            addSubforumGroup.TabIndex = 4;
            addSubforumGroup.TabStop = false;
            addSubforumGroup.Text = "Add Subforum";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(addThreadInput);
            groupBox1.Controls.Add(addThreadBtn);
            groupBox1.Location = new Point(280, 442);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(333, 70);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Thread";
            // 
            // addThreadInput
            // 
            addThreadInput.Location = new Point(11, 26);
            addThreadInput.Name = "addThreadInput";
            addThreadInput.Size = new Size(227, 27);
            addThreadInput.TabIndex = 3;
            // 
            // addThreadBtn
            // 
            addThreadBtn.Location = new Point(244, 26);
            addThreadBtn.Name = "addThreadBtn";
            addThreadBtn.Size = new Size(83, 29);
            addThreadBtn.TabIndex = 1;
            addThreadBtn.Text = "Add";
            addThreadBtn.UseVisualStyleBackColor = true;
            addThreadBtn.Click += addThreadBtn_Click;
            // 
            // addPostTextBox
            // 
            addPostTextBox.BackColor = SystemColors.HighlightText;
            addPostTextBox.Location = new Point(626, 407);
            addPostTextBox.Name = "addPostTextBox";
            addPostTextBox.Size = new Size(380, 105);
            addPostTextBox.TabIndex = 6;
            addPostTextBox.Text = "";
            // 
            // addPostBtn
            // 
            addPostBtn.Location = new Point(1012, 407);
            addPostBtn.Name = "addPostBtn";
            addPostBtn.Size = new Size(94, 29);
            addPostBtn.TabIndex = 7;
            addPostBtn.Text = "Post";
            addPostBtn.UseVisualStyleBackColor = true;
            addPostBtn.Click += addPostBtn_Click;
            // 
            // editPostBtn
            // 
            editPostBtn.Location = new Point(1012, 442);
            editPostBtn.Name = "editPostBtn";
            editPostBtn.Size = new Size(94, 29);
            editPostBtn.TabIndex = 8;
            editPostBtn.Text = "Update";
            editPostBtn.UseVisualStyleBackColor = true;
            editPostBtn.Click += editPostBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(17, 3);
            label1.Name = "label1";
            label1.Size = new Size(120, 32);
            label1.TabIndex = 9;
            label1.Text = "Subforum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(280, 3);
            label2.Name = "label2";
            label2.Size = new Size(88, 32);
            label2.TabIndex = 10;
            label2.Text = "Thread";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(619, 3);
            label3.Name = "label3";
            label3.Size = new Size(58, 32);
            label3.TabIndex = 11;
            label3.Text = "Post";
            // 
            // subforumPanel
            // 
            subforumPanel.AutoScroll = true;
            subforumPanel.Location = new Point(17, 38);
            subforumPanel.Name = "subforumPanel";
            subforumPanel.Size = new Size(250, 398);
            subforumPanel.TabIndex = 12;
            // 
            // threadPanel
            // 
            threadPanel.AutoScroll = true;
            threadPanel.Location = new Point(280, 38);
            threadPanel.Name = "threadPanel";
            threadPanel.Size = new Size(333, 398);
            threadPanel.TabIndex = 13;
            // 
            // postPanel
            // 
            postPanel.AutoScroll = true;
            postPanel.Location = new Point(626, 38);
            postPanel.Name = "postPanel";
            postPanel.Size = new Size(480, 361);
            postPanel.TabIndex = 14;
            // 
            // reloadBtn
            // 
            reloadBtn.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            reloadBtn.Location = new Point(1066, 3);
            reloadBtn.Name = "reloadBtn";
            reloadBtn.Size = new Size(37, 32);
            reloadBtn.TabIndex = 15;
            reloadBtn.Text = "↻";
            reloadBtn.UseVisualStyleBackColor = true;
            reloadBtn.Click += reloadBtn_Click;
            // 
            // ForumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1115, 524);
            Controls.Add(reloadBtn);
            Controls.Add(postPanel);
            Controls.Add(threadPanel);
            Controls.Add(subforumPanel);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(editPostBtn);
            Controls.Add(addPostBtn);
            Controls.Add(addPostTextBox);
            Controls.Add(groupBox1);
            Controls.Add(addSubforumGroup);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ForumForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VCLForum";
            FormClosing += ForumForm_FormClosing;
            Load += ForumForm_Load;
            addSubforumGroup.ResumeLayout(false);
            addSubforumGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button addSubforumBtn;
        private TextBox addSubforumTextbox;
        private GroupBox addSubforumGroup;
        private GroupBox groupBox1;
        private TextBox addThreadInput;
        private Button addThreadBtn;
        private RichTextBox addPostTextBox;
        private Button addPostBtn;
        private Button editPostBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private FlowLayoutPanel subforumPanel;
        private FlowLayoutPanel threadPanel;
        private FlowLayoutPanel postPanel;
        private Button reloadBtn;
    }
}