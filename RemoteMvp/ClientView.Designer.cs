namespace RemoteMvpClient
{
    partial class ClientView
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
            button1 = new Button();
            button2 = new Button();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            _adminCheck = new CheckBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(154, 135);
            button1.Name = "button1";
            button1.Size = new Size(116, 28);
            button1.TabIndex = 0;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += login_Click;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(12, 136);
            button2.Name = "button2";
            button2.Size = new Size(80, 27);
            button2.TabIndex = 1;
            button2.Text = "Register";
            button2.UseVisualStyleBackColor = true;
            button2.Click += register_Click;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(12, 30);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(258, 23);
            tbUsername.TabIndex = 2;
            tbUsername.TextChanged += TbUsernameTextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(12, 83);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(258, 23);
            tbPassword.TabIndex = 3;
            tbPassword.TextChanged += TbPasswordTextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "User Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // _adminCheck
            // 
            _adminCheck.AutoSize = true;
            _adminCheck.Location = new Point(98, 61);
            _adminCheck.Name = "_adminCheck";
            _adminCheck.Size = new Size(62, 19);
            _adminCheck.TabIndex = 5;
            _adminCheck.Text = "Admin";
            _adminCheck.UseVisualStyleBackColor = true;
            // 
            // ClientView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 181);
            Controls.Add(_adminCheck);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(tbUsername);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ClientView";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private CheckBox _adminCheck;
    }
}