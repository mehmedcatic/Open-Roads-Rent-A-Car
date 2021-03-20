using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class VehicleInsertUpdateRequest
    {
        public int ManufacturedYear { get; set; }
        public int PowerInHp { get; set; }
        public int DoorsCount { get; set; }
        public int SeatsCount { get; set; }
        public float PriceByDay { get; set; }
        public string RegistrationNumber { get; set; }
        public byte[] Picture { get; set; }
        public byte[] PictureThumb { get; set; }
        public bool Available { get; set; }
        public bool Active { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleCategoryId { get; set; }
        public int VehicleModelId { get; set; }
        public int VehicleFuelTypeId { get; set; }
        public int VehicleTransmissionTypeId { get; set; }
        public int BranchId { get; set; }
    }
}
