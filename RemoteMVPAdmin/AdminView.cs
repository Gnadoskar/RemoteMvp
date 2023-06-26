using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RemoteMVPAdmin
{
    public partial class AdminView : Form
    {
        // ---- event

        public event EventHandler AdminRequested;
        // --- member

        private List<Tuple<string, string>> _userForListBox = new List<Tuple<string, string>>();

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
            MessageBox.Show("Successfully Connected as Admin", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            _userForListBox = ConvertData(message);

            _UserListBox.Items.Clear();

            foreach (var user in _userForListBox)
            {
                _UserListBox.Items.Add(user);

            }

        }

        private List<Tuple<string, string>> ConvertData(string userListString)
        {
            List<Tuple<string, string>> userConverted = new List<Tuple<string, string>>();

            string[] lines = userListString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {

                string[] parts = line.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2)
                {
                    //string name = parts[0].Substring(parts[0].IndexOf(":") + 2);
                    //string password = parts[1].Substring(parts[1].IndexOf(":") + 2);
                    string name = parts[0] + "\t";
                    string password = parts[1];

                    userConverted.Add(Tuple.Create(name, password));
                }
                else if (parts.Length == 1)
                {
                    string name = parts[0].Substring(parts[0].IndexOf(":") + 2);
                    userConverted.Add(Tuple.Create(name, "Missing!"));


                }
                else
                {
                    userConverted.Add(Tuple.Create("Error", "Missing!"));

                }
            }

            return userConverted;
        }
        //------------Delete Button-------------

        private void _btnDeleteUser_Click(object sender, EventArgs e)
        {

        }
    }
}