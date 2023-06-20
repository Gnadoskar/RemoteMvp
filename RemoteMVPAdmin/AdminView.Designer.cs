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
            _btnConnect = new Button();
            label2 = new Label();
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
            // _btnConnect
            // 
            _btnConnect.Location = new Point(431, 37);
            _btnConnect.Name = "_btnConnect";
            _btnConnect.Size = new Size(75, 23);
            _btnConnect.TabIndex = 3;
            _btnConnect.Text = "Connect";
            _btnConnect.UseVisualStyleBackColor = true;
            _btnConnect.Click += _btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(341, 9);
            label2.Name = "label2";
            label2.Size = new Size(165, 15);
            label2.TabIndex = 4;
            label2.Text = "Press to connect to the server:";
            // 
            // AdminView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 272);
            Controls.Add(label2);
            Controls.Add(_btnConnect);
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
        private Button _btnConnect;
        private Label label2;
    }
}