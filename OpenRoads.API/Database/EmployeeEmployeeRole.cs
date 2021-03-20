using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class EmployeeEmployeeRole
    {
        public int EmployeeEmployeeRolesId { get; set; }
        public DateTime ChangeDate { get; set; }
        public int EmployeeId { get; set; }
        public int EmployeeRolesId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual EmployeeRole EmployeeRoles { get; set; }
    }
}
