using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteMvpClient
{
    public class ClientModel
    {
        public string SurName { get; init; }
        public string PreName { get; init; }
        public string FullName => $"{PreName} {SurName}";
        public DateTime Birthday { get; set; }

        public double AgeInYears { get; set; }

        public ClientModel(string surName, string preName, DateTime birthday)
        {
            SurName = surName;
            PreName = preName;
            Birthday = birthday;
        }
        // Hallo geht jz?
        
    }
}
