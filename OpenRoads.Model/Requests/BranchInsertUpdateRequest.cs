using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class BranchInsertUpdateRequest
    {
        public string FullName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ZIPCode { get; set; }

        public string PhoneNumber { get; set; }

        public int WorkingHoursFrom { get; set; }

        public int WorkingHoursTo { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public int CountryId { get; set; }
    }
}
