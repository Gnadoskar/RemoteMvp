using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMVPAdmin
{
    internal class AdminModel
    {
        public event EventHandler ModelUpdated;

        public string UserList { get; set; }

        internal void SavaData(string? message)
        {
            UserList = message;

            ModelUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
