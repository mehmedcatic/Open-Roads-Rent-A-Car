using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Client
    {
        public Client()
        {
            Ratings = new HashSet<Rating>();
            Reservations = new HashSet<Reservation>();
        }

        public int ClientId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool Active { get; set; }
        public int PersonId { get; set; }
        public byte[] ProfilePicture { get; set; }
        public byte[] ProfilePictureThumb { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
