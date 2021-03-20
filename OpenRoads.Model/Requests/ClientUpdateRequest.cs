using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class ClientUpdateRequest
    {
        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] ProfilePictureThumb { get; set; }

        public int LoginDataId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string CleasPassword { get; set; }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }

    }
}
