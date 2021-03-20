using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            EmployeeEmployeeRoles = new HashSet<EmployeeEmployeeRole>();
        }

        public int EmployeeRolesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<EmployeeEmployeeRole> EmployeeEmployeeRoles { get; set; }
    }
}
