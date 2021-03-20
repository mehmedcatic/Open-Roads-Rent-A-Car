using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class EmployeeSearchRequest
    {
        public int? BranchId { get; set; }
        public int? EmployeeRolesId { get; set; }
        public string Username { get; set; }
    }
}
