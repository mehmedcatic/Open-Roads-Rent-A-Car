using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class VehicleCategory
    {
        public VehicleCategory()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
