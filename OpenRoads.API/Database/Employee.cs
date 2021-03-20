using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeEmployeeRoles = new HashSet<EmployeeEmployeeRole>();
        }

        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmployeeCode { get; set; }
        public string JobDescription { get; set; }
        public bool Active { get; set; }
        public int BranchId { get; set; }
        public int PersonId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<EmployeeEmployeeRole> EmployeeEmployeeRoles { get; set; }
    }
}
