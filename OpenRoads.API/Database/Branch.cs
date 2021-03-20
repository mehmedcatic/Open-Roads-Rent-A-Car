using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Branch
    {
        public Branch()
        {
            Employees = new HashSet<Employee>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int BranchId { get; set; }
        public string FullName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkingHoursFrom { get; set; }
        public int WorkingHoursTo { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
