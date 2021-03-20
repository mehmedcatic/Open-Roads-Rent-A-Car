using System;
using System.Collections.Generic;
using System.Text;

namespace OpenRoads.Model.Requests
{
    public class ClientSearchRequest
    {
        public int? CountryId { get; set; }
        public string Username { get; set; }
    }
}
