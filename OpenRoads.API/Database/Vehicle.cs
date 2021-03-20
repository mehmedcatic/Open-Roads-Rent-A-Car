using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Ratings = new HashSet<Rating>();
            Reservations = new HashSet<Reservation>();
        }

        public int VehicleId { get; set; }
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

        public virtual Branch Branch { get; set; }
        public virtual VehicleCategory VehicleCategory { get; set; }
        public virtual VehicleFuelType VehicleFuelType { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual VehicleTransmissionType VehicleTransmissionType { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
