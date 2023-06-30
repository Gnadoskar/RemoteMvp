using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace RemoteMVPAdmin
{
    public partial class AdminView : Form
    {
        // ---- event

        public event EventHandler AdminRequested;
        public event EventHandler AdminDeleted;
        // --- member
        public Tuple<string, string> _selectedUserDelete { get; set; }

        private List<Tuple<string, string>> _userForListBox = new List<Tuple<string, string>>();

        public AdminView()
        {
            InitializeComponent();
        }

        //---------Connect Button-----------------------
        private void _btnConnect_Click(object sender, EventArgs e)
        {
            AdminRequested?.Invoke(this, EventArgs.Empty);
        }

        //---------Message Box and List Update (if Success)
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
        //-------------Converts Data for ListBox (View)-----------------
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

            if(ListViewNotEmpty())
            {
                if(OnlyOnePersonSelected())
                {
                    string selectedItem = _UserListBox.SelectedItem.ToString();

                    string[] splitString = selectedItem.Split(',');

                    _selectedUserDelete = Tuple.Create(splitString[0].Trim(), splitString[1].Trim());
                }
            }

           AdminDeleted?.Invoke(this, EventArgs.Empty);


        }

        private bool OnlyOnePersonSelected()
        {
            if(_UserListBox.SelectedItems.Count == 1)
            {
                return true;
            }
            else if(_UserListBox.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only 1 person for details", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                MessageBox.Show("No Person selected!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }


        private bool ListViewNotEmpty()
        {
            if(_UserListBox.Items.Count >0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Error, Please click on the Connect Button!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}