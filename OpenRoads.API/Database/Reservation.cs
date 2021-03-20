using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Reservation
    {
        public Reservation()
        {
            Ratings = new HashSet<Rating>();
        }

        public int ReservationId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public float Price { get; set; }
        public DateTime CreationDate { get; set; }
        public string AdditionalInfo { get; set; }
        public bool Canceled { get; set; }
        public bool Active { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int InsuranceId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
