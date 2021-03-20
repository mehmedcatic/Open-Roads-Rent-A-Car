using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model
{
    public class LoginDataModel
    {
        public int LoginDataId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
    }
}
