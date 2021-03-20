using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class EmployeeInsertUpdateRequest
    {

        //Person att
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        //public int LoginDataId { get; set; }
        public int CountryId { get; set; }


        //Employee att
        public DateTime HireDate { get; set; }
        public string EmployeeCode { get; set; }
        public string JobDescription { get; set; }
        public bool Active { get; set; }
        public int BranchId { get; set; }
        //public int PersonId { get; set; }


        //LoginData att
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public string CleasPassword { get; set; }


        public int EmployeeRoleId { get; set; }
    }
}
