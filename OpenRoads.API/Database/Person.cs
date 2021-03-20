using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Person
    {
        public Person()
        {
            Clients = new HashSet<Client>();
            Employees = new HashSet<Employee>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int LoginDataId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual LoginData LoginData { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
