using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Insurance
    {
        public Insurance()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int InsuranceId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
