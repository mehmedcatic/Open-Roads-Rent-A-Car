using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class VehicleSearchRequest
    {
        public int? VehicleTypeId { get; set; }
        public int? VehicleCategoryId { get; set; }
        public int? VehicleModelId { get; set; }
        public int? VehicleFuelTypeId { get; set; }
        public int? VehicleTransmissionTypeId { get; set; }
        public int? VehicleManufacturerId { get; set; }
    }
}
