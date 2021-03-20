using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmployeeCode { get; set; }
        public string JobDescription { get; set; }
        public bool Active { get; set; }
        public int BranchId { get; set; }
        public int PersonId { get; set; }
    }
}
