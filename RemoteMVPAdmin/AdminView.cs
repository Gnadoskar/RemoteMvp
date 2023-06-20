using static System.Net.Mime.MediaTypeNames;

namespace RemoteMVPAdmin
{
    public partial class AdminView : Form
    {

        public event EventHandler AdminRequested;

        public AdminView()
        {
            InitializeComponent();
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            AdminRequested?.Invoke(this, EventArgs.Empty);
        }

        //---------Message Box----------
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ConnectionSuccess(string message)
        {
            MessageBox.Show(message, "You are now Admin", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }







    }
}