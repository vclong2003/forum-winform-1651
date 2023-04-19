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
            subforumListbox = new ListBox();
            addSubforumBtn = new Button();
            threadListbox = new ListBox();
            addSubforumTextbox = new TextBox();
            addSubforumGroup = new GroupBox();
            groupBox1 = new GroupBox();
            addThreadInput = new TextBox();
            addThreadBtn = new Button();
            addSubforumGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // subforumListbox
            // 
            subforumListbox.FormattingEnabled = true;
            subforumListbox.ItemHeight = 20;
            subforumListbox.Location = new Point(12, 12);
            subforumListbox.Name = "subforumListbox";
            subforumListbox.Size = new Size(243, 424);
            subforumListbox.TabIndex = 0;
            subforumListbox.SelectedIndexChanged += subforumListbox_SelectedIndexChanged;
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
            // threadListbox
            // 
            threadListbox.FormattingEnabled = true;
            threadListbox.ItemHeight = 20;
            threadListbox.Location = new Point(276, 12);
            threadListbox.Name = "threadListbox";
            threadListbox.Size = new Size(333, 424);
            threadListbox.TabIndex = 2;
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
            addSubforumGroup.Location = new Point(2, 442);
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
            groupBox1.Location = new Point(276, 442);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(333, 70);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Thread";
            groupBox1.Enter += groupBox1_Enter;
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
            // ForumForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 518);
            Controls.Add(groupBox1);
            Controls.Add(addSubforumGroup);
            Controls.Add(threadListbox);
            Controls.Add(subforumListbox);
            Name = "ForumForm";
            Text = "ForumForm";
            FormClosing += ForumForm_FormClosing;
            Load += ForumForm_Load;
            addSubforumGroup.ResumeLayout(false);
            addSubforumGroup.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox subforumListbox;
        private Button addSubforumBtn;
        private ListBox threadListbox;
        private TextBox addSubforumTextbox;
        private GroupBox addSubforumGroup;
        private GroupBox groupBox1;
        private TextBox addThreadInput;
        private Button addThreadBtn;
    }
}