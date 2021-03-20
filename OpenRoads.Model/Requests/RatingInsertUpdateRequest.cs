using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class RatingInsertUpdateRequest
    {
        public int RatingInt { get; set; }
        public string RatingString { get; set; }
        public DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int ReservationId { get; set; }
    }
}
