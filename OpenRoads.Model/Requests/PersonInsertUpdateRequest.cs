using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class PersonInsertUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int LoginDataId { get; set; }
        public int CountryId { get; set; }
    }
}
