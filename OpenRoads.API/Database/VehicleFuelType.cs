using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class VehicleFuelType
    {
        public VehicleFuelType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleFuelTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
