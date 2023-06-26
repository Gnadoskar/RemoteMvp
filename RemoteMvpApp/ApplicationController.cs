using RemoteMvpLib;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RemoteMvpApp
{
    internal class ApplicationController
    {
        // Model 
        private readonly Userlist _usersClass;

        // ActionEndpoint (to be called by the view)
        private readonly IActionEndpoint _actionEndpoint;

        List<Tuple<string, string>> _usersForAdmin = new List<Tuple<string, string>>();

        public ApplicationController(IActionEndpoint actionEndpoint)
        {
            // Create new Model
            string filepath = Path.Combine("..", "..", "Registered_People.csv");
            _usersClass = new Userlist(filepath);

            // Link ActionEndpoint to local method
            _actionEndpoint = actionEndpoint;
            _actionEndpoint.OnActionPerformed += EndpointOnActionPerformed;
           // _usersClass.UsersForAdmin += OnUsersForAdmin;

            // Auf event subben
            //_usersClass.GetUserList +=  OnGetUserList;     
        }

       

        public void RunActionEndPoint() => _actionEndpoint.RunActionEndpoint();


        public Task RunActionEndPointAsync()
        {
            var task = new Task(_actionEndpoint.RunActionEndpoint);
            task.Start();
            return task;
        }

        private void EndpointOnActionPerformed(object? sender, RemoteActionRequest request)
        {
            if (sender is not RemoteActionEndpoint) return;

            var handler = (RemoteActionEndpoint)sender;
            switch (request.Type)
            {
                
                case ActionType.Login:
                    Process_Login(handler, request.UserName, request.Password);
                    break;
                case ActionType.Register:
                    Process_Register(handler, request.UserName, request.Password);
                    break;
                case ActionType.Admin:
                    Process_Admin(handler, request.UserName, request.Password);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Request not supported");
            }
        }
        
        private void Process_Login(RemoteActionEndpoint handler, string username, string password)
        {
            switch (_usersClass.LoginUser(username, password))
            {
                case UserListActionResult.AccessGranted:
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Success, $"Access granted for {username}."));
                    break;
                case UserListActionResult.UserOkPasswordWrong:
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, "Wrong password.")); 
                    break;
                case UserListActionResult.UserNotExisting:
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, $"User {username} not existing."));
                    break;
                default:
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, "Unsupported action."));
                    break;
            }
        }

        private void Process_Register(RemoteActionEndpoint handler, string username, string password)
        {
            switch (_usersClass.RegisterUser(username, password))
            {
                case UserListActionResult.UserAlreadyExists:
                    Console.WriteLine("Error registering: User already existing.");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, $"Error! User {username} is already existing."));
                    break;
                case UserListActionResult.RegistrationOk:
                    Console.WriteLine("User registration OK.");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Success, $"Registration successful for {username}. You can now login."));
                    break;
                default:
                    Console.WriteLine("Unknown action.");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, "Unsupported operation."));
                    break;
            }
        }

        private void Process_Admin(RemoteActionEndpoint handler, string username, string password)
        {
              _usersForAdmin =  _usersClass.GetUserList();  //methode die die Userliste aus der Csv lädt, in der _userClass speichert und als Liste von Tuples zurück gibt

            switch (_usersClass.ChekUserlistNotNull())  // überprüfung ob die Liste user beinhaltet
            {
                case UserListActionResult.UserListIsNotNull:
                    Console.WriteLine("User List OK");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Success, $"{ _usersForAdmin.ToString()}" ));
                    break;

                case UserListActionResult.UserListIsNull:
                    Console.WriteLine("No UserList found!");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, "Error, no Users found!"));
                    break;

                default:
                    Console.WriteLine("Unknown action.");
                    handler.PerformActionResponse(handler.Handler, new RemoteActionResponse(ResponseType.Error, "Unsupported operation."));
                    break;
                    

            }   

        }

        public override string ToString()
        {
            string returnValue = null;

            foreach (var tuple in _usersForAdmin)
            {

                returnValue += $"Name: {tuple.Item1},\t Passwort: {tuple.Item2}" + Environment.NewLine;

            }

            return returnValue;
        }


    


        //private void OnUsersForAdmin(object? sender, List<Userlist.User> userList)
        //{
        //    


        //}



        /// <summary>
        /// Helper method to parse semicolon-separated key=value pairs
        /// </summary>
        /// <param name="cmd">A string semicolon-separated key=value pairs</param>
        /// <returns>A dictionary with key value pairs</returns>
        private Dictionary<string, string> ProcessCmd(string cmd)
        {
            cmd = cmd.TrimEnd(';');

            string[] parts = cmd.Split(new char[] { ';' });

            Dictionary<string, string> keyValuePairs = cmd.Split(';')
                .Select(value => value.Split('='))
                .ToDictionary(pair => pair[0], pair => pair[1]);

            return keyValuePairs;
        }
    }
}
