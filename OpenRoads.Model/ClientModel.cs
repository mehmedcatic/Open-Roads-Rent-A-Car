using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] ProfilePictureThumb { get; set; }
        public int PersonId { get; set; }
    }
}
