using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class VehicleManufacturer
    {
        public VehicleManufacturer()
        {
            VehicleModels = new HashSet<VehicleModel>();
        }

        public int VehicleManufacturerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
