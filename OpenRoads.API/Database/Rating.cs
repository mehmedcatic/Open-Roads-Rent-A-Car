using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int RatingInt { get; set; }
        public string RatingString { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int ReservationId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
