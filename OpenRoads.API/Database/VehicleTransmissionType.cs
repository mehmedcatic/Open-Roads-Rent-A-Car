using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class VehicleTransmissionType
    {
        public VehicleTransmissionType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int VehicleTransmissionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
