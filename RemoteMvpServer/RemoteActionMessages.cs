﻿

namespace RemoteMvpLib
{
    public enum ActionType
    {
        Register,
        Login,
        Logout
    }

    public class RemoteActionRequest
    {
        public ActionType Type { get; }

        public string UserName { get; }

        public string Password { get; }

        public bool AdminCheck { get; }

        public RemoteActionRequest(ActionType type, string username, string password,bool admin)
        {
            Type = type;
            UserName = username;
            Password = password;
            AdminCheck = admin;
        }
    }

    public enum ResponseType
    {
        Success,
        Error
    }

    public class RemoteActionResponse
    {
        public ResponseType Type { get; set; }

        public string? Message { get; set; }

        public RemoteActionResponse(ResponseType type, string? message)
        {
            Type = type;
            Message = message;
        }
    }
}
