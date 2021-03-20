using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class LoginData
    {
        public LoginData()
        {
            People = new HashSet<Person>();
        }

        public int LoginDataId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
