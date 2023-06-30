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

        //---- method for deleting one user from the list
        public UserListActionResult DeleteUser(string username, string passowrd)
        {
            var item = UserListActionResult.UnsuccessfulDeleted;
            User userToDelete = null;

            foreach (var user in _users) 
            {
                if (user.UserName.ToString() == username.ToString())
                {
                    userToDelete = user;
                    //_users.Remove(user);
                    item = UserListActionResult.SuccessfullyDeleted;
                } 
            }

            _users.Remove(userToDelete);
            SaveUserListToCsv(_csvFilePath, _users); //erneuert die csv datei
                                                     //
           
            return item;
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

        //-----Alle Benutzer entfernen
        public void RemoveAllUsers()
        {
            _users.Clear();  // Alle Benutzer löschen
            SaveUserListToCsv(_csvFilePath, _users);  // Leere Benutzerliste in CSV-Datei speichern
        }

        //-------Load User for Admin-------------------------------- 
        public List<Tuple<string, string>> GetUserList()
        {
            //  _users = LoadUserListFromCsv(_csvFilePath);

            List<User> usersForAdmin = _users;
          List< Tuple<string,string> > userListReturn = new List<Tuple<string, string>>();          

            foreach (var user in usersForAdmin)
            {
                try
                {                   
                    userListReturn.Add( Tuple.Create(user.UserName, user.Password) );
                }
                catch (Exception)
                {
                    userListReturn.Add(Tuple.Create("Error", "---"));

                }  
            }

            return userListReturn;           

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
        
        //---Benutzerliste in csv schreiben
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




