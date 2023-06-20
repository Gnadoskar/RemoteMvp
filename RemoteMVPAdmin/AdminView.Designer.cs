namespace RemoteMVPAdmin
{
    partial class AdminView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _UserListBox = new ListBox();
            label1 = new Label();
            _btnDeleteUser = new Button();
            SuspendLayout();
            // 
            // _UserListBox
            // 
            _UserListBox.FormattingEnabled = true;
            _UserListBox.ItemHeight = 15;
            _UserListBox.Location = new Point(12, 37);
            _UserListBox.Name = "_UserListBox";
            _UserListBox.Size = new Size(395, 214);
            _UserListBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 1;
            label1.Text = "Registered Users:";
            // 
            // _btnDeleteUser
            // 
            _btnDeleteUser.Location = new Point(431, 228);
            _btnDeleteUser.Name = "_btnDeleteUser";
            _btnDeleteUser.Size = new Size(89, 23);
            _btnDeleteUser.TabIndex = 2;
            _btnDeleteUser.Text = "Delete User";
            _btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 272);
            Controls.Add(_btnDeleteUser);
            Controls.Add(label1);
            Controls.Add(_UserListBox);
            Name = "AdminView";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox _UserListBox;
        private Label label1;
        private Button _btnDeleteUser;
    }
}