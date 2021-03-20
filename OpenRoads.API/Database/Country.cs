using System;
using System.Collections.Generic;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class Country
    {
        public Country()
        {
            Branches = new HashSet<Branch>();
            People = new HashSet<Person>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
