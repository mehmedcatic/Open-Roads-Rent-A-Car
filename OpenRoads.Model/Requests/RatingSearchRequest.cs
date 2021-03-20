using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class RatingSearchRequest
    {
        public int? VehicleId { get; set; }
        public int? ClientId { get; set; }
    }
}
