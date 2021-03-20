using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRoadsWebAPI.Service
{
    public interface IRecommenderService
    {
        List<OpenRoads.Model.VehicleModel> GetVehicleRecommendation(int id);
    }
}
