using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OpenRoads.API.Database;

namespace OpenRoads.API
{
    public class SetupService
    {
        public static void Init(openRoadsContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
