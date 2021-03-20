using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class ReservationSearchRequest
    {
        public int? VehicleId { get; set; }
        public int? InsuranceId { get; set; }
        public int? ReservationYear { get; set; }
        public int? VehicleManufacturerId { get; set; }
        public int? ClientId { get; set; }
    }
}
