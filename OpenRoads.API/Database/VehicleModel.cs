using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class VehicleModel
    {
        public VehicleModel()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleModelId { get; set; }
        public string Name { get; set; }
        public int VehicleManufacturerId { get; set; }

        public virtual VehicleManufacturer VehicleManufacturer { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
