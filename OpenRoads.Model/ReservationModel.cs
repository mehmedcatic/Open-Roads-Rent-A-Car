using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public float Price { get; set; }
        public DateTime CreationDate { get; set; }
        public string AdditionalInfo { get; set; }
        public bool Canceled { get; set; }
        public bool Active { get; set; }
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
        public int InsuranceId { get; set; }
    }
}
