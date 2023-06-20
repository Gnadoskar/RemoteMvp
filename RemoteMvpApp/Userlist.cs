using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RemoteMvpApp
{
    // Mögliche Ergebnisse von Aktionen in der Userlist-Klasse
    public enum UserListActionResult
    {
        UserNotExisting,
        UserAlreadyExists,
        UserOkPasswordWrong,
        AccessGranted,
        RegistrationOk
    }

    internal class Userlist
    {
        // Interne Klasse zur Repräsentation eines Benutzers
        private record User(string UserName, string Password);

        private List<User> _users;  // Liste der Benutzer
        private string _csvFilePath;  // Pfad zur CSV-Datei

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

        // Benutzerliste aus CSV-Datei laden
        private List<User> LoadUserListFromCsv(string csvFilePath)
        {
            List<User> users = new List<User>();
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
            return users;
        }

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
//        private readonly List<User> _users;

//        public Userlist()
//        {
//            _users = new List<User>();
//        }

//        public UserListActionResult LoginUser(string username, string password)
//        {
//            foreach (var user in _users.Where(user => user.UserName.Equals(username)))
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
//            if (_users.Any(user => user.UserName.Equals(username)))
//            {
//                return UserListActionResult.UserAlreadyExists;
//            }

//            User newUser = new(username, password);
//            _users.Add(newUser);
//            return UserListActionResult.RegistrationOk;
//        }

//        public void RemoveUser(string username)
//        {
//            _users.RemoveAll(user => user.UserName.Equals(username));
//        }

//        public void RemoveAllUsers()
//        {
//            _users.Clear();
//        }


//    }

//}

