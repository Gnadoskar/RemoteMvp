using Microsoft.VisualBasic;

namespace RemoteMvpClient
{
    public partial class ClientView : Form
    {

        public event EventHandler<Tuple<string, string>> LoginRequested;
        public event EventHandler<Tuple<string, string>> RegisterRequested;
        private bool _checkAdminBoxState = false;

        public ClientView()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            LoginRequested?.Invoke(sender, new Tuple<string, string>(tbUsername.Text, tbPassword.Text));
           
        }

        private void register_Click(object sender, EventArgs e)
        {
            RegisterRequested?.Invoke(sender, new Tuple<string, string>(tbUsername.Text, tbPassword.Text));
        }


        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void LoginOk(string text)
        {
            MessageBox.Show(text, "Login", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void RegisterOk(string text)
        {
            MessageBox.Show(text, "Register", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void TbUsernameTextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length > 0 && tbPassword.Text.Length > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void TbPasswordTextChanged(object sender, EventArgs e)
        {
            if (tbUsername.Text.Length > 0 && tbPassword.Text.Length > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void _adminCheck_CheckedChanged(object sender, EventArgs e)
        {
            if(!_checkAdminBoxState)
            {
                _checkAdminBoxState = true;
            }
            else
            {
                _checkAdminBoxState = false;
            }
          

            
        }
    }
}