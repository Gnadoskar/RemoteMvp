using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RemoteMvpApp
{
    // Mögliche Ergebnisse von Aktionen in der Userlist-Klasse
    public enum UserListActionResult
    {
        UserNotExisting,
        UserAlreadyExists,
        UserOkPasswordWrong,
        AccessGranted,
        RegistrationOk,
        UserListIsNull,
        UserListIsNotNull,
        SuccessfullyDeleted,
        UnsuccessfulDeleted


    }

    public class Userlist
    {
        // Interne Klasse zur Repräsentation eines Benutzers
        public record User(string UserName, string Password);
       
        private List<User> _users;  // Liste der Benutzer      
        private string _csvFilePath;   // Pfad zur CSV-Datei

       // public event EventHandler <List<User>> UsersForAdmin { get;set; }

        public Userlist(string csvFilePath)
        {
            _users = LoadUserListFromCsv(csvFilePath);  // Benutzerliste aus CSV-Datei laden
            _csvFilePath = csvFilePath;
        }

        // Benutzeranmeldung
        public UserListActionResult LoginUser(string username, string password)
        {
            foreach (var user in _users.Where(user => user.UserName.Equals(username)))
            {
                if (user.Password.Equals(password))
                {
                    return UserListActionResult.AccessGranted;  // Zugriff gewährt
                }
                else
                {
                    return UserListActionResult.UserOkPasswordWrong;  // Benutzer vorhanden, aber falsches Passwort
                }
            }

            return UserListActionResult.UserNotExisting;  // Benutzer existiert nicht
        }

        public UserListActionResult DeleteUser(string username, string passowrd)
        {
            foreach(var user in _users) 
            {
                if (user.UserName.Equals(username))
                {
                    _users.Remove(user);
                    return UserListActionResult.SuccessfullyDeleted;
                } 
            }

            return UserListActionResult.UnsuccessfulDeleted;
        }



        // Gibt es Benutzer?

        public UserListActionResult ChekUserlistNotNull()
        {
            if(_users.Count == 0)
            {
                return UserListActionResult.UserListIsNull;

            }

            return UserListActionResult.UserListIsNotNull;
        }



        // Benutzerregistrierung
        public UserListActionResult RegisterUser(string username, string password)
        {
            if (_users.Any(user => user.UserName.Equals(username)))
            {
                return UserListActionResult.UserAlreadyExists;  // Benutzer existiert bereits
            }

            User newUser = new(username, password);
            _users.Add(newUser);  // Neuen Benutzer hinzufügen
            SaveUserListToCsv(_csvFilePath, _users);  // Benutzerliste in CSV-Datei speichern
            return UserListActionResult.RegistrationOk;  // Registrierung erfolgreich
        }

        // Benutzer entfernen
        public void RemoveUser(string username)
        {
            _users.RemoveAll(user => user.UserName.Equals(username));  // Benutzer entfernen
            SaveUserListToCsv(_csvFilePath, _users);  // Benutzerliste in CSV-Datei speichern
        }

        // Alle Benutzer entfernen
        public void RemoveAllUsers()
        {
            _users.Clear();  // Alle Benutzer löschen
            SaveUserListToCsv(_csvFilePath, _users);  // Leere Benutzerliste in CSV-Datei speichern
        }

        // Load User for Admin 
        public List<Tuple<string, string>> GetUserList()
        {
            _users = LoadUserListFromCsv(_csvFilePath);

          List<User> usersForAdmin = LoadUserListFromCsv(_csvFilePath);
          List< Tuple<string,string> > userListreturn = new List<Tuple<string, string>>();          

            foreach (var user in usersForAdmin)
            {
                try
                {                   
                    userListreturn.Add( Tuple.Create(user.UserName, user.Password) );
                }
                catch (Exception)
                {
                    userListreturn.Add(Tuple.Create("Error", "---"));

                }  
            }

            return userListreturn;

            //Event -> ApplicationController übergibt List<user>

            //UsersForAdmin?.Invoke(this, _usersForAdmin);

        }


        // Benutzerliste aus CSV-Datei laden
        private List<User> LoadUserListFromCsv(string csvFilePath)
        {
           
            List<User> users = new List<User>();
            try
            {
                using (var reader = new StreamReader(csvFilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] data = line.Split(',');
                        string username = data[0];
                        string password = data[1];
                        User user = new User(username, password);
                        users.Add(user);
                    }
                }
                
            }
            catch (Exception e)
            {
                        
            }

            return users;
        }

        //public List<User> GetUserList()
        //{          

        //    return _usersClass;
        //}


        // Benutzerliste in CSV-Datei speichern
        private void SaveUserListToCsv(string csvFilePath, List<User> userList)
        {
            using (var writer = new StreamWriter(csvFilePath))
            {
                foreach (User user in userList)
                {
                    string line = $"{user.UserName},{user.Password}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RemoteMvpApp
//{
//    public enum UserListActionResult
//    {
//        UserNotExisting,
//        UserAlreadyExists,
//        UserOkPasswordWrong,
//        AccessGranted,
//        RegistrationOk
//    }

//    internal class Userlist
//    {
//        private record User(string UserName, string Password);
//        private readonly List<User> _usersClass;

//        public Userlist()
//        {
//            _usersClass = new List<User>();
//        }

//        public UserListActionResult LoginUser(string username, string password)
//        {
//            foreach (var user in _usersClass.Where(user => user.UserName.Equals(username)))
//            {
//                if (user.Password.Equals(password))
//                {
//                    return UserListActionResult.AccessGranted;
//                }
//                else
//                {
//                    return UserListActionResult.UserOkPasswordWrong;
//                }
//            }

//            return UserListActionResult.UserNotExisting;
//        }

//        public UserListActionResult RegisterUser(string username, string password)
//        {
//            if (_usersClass.Any(user => user.UserName.Equals(username)))
//            {
//                return UserListActionResult.UserAlreadyExists;
//            }

//            User newUser = new(username, password);
//            _usersClass.Add(newUser);
//            return UserListActionResult.RegistrationOk;
//        }

//        public void RemoveUser(string username)
//        {
//            _usersClass.RemoveAll(user => user.UserName.Equals(username));
//        }

//        public void RemoveAllUsers()
//        {
//            _usersClass.Clear();
//        }


//    }

//}

