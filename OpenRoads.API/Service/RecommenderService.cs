using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using VehicleModel = OpenRoads.Model.VehicleModel;

namespace OpenRoadsWebAPI.Service
{
    public class RecommenderService : IRecommenderService
    {
        private readonly openRoadsContext _context;
        private readonly IMapper _mapper;
        public int numberOfRecommendations = 5;

        public RecommenderService(openRoadsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        public List<OpenRoads.Model.VehicleModel> GetVehicleRecommendation(int clientId)
        {
            //Get all vehicles and all reservations from desired client from db
            var vehicles = _context.Vehicles.ToList();

            var reservations = _context.Reservations.Where(x => x.ClientId == clientId).ToList();
            if (reservations.Count > 0)
            {
                //Create a new list of vehicleIds
                List<int> rentedVehiclesList = new List<int>();
                foreach (var x in reservations)
                {
                    rentedVehiclesList.Add(x.VehicleId);
                }

                List<int> indexToRemove = new List<int>();

                //Check if vehicle is already contained (same vehicle booked more than once)
                for (int i = 0; i < rentedVehiclesList.Count; i++)
                {
                    for (int j = i+1; j < rentedVehiclesList.Count; j++)
                    {
                        if (rentedVehiclesList[i] == rentedVehiclesList[j])
                        {
                            if(!indexToRemove.Contains(j))
                                indexToRemove.Add(j);
                        }
                    }
                }

                //Sort the array of index ids descending
                indexToRemove.Sort((x,y) => y.CompareTo(x));

                //Remove the duplicates from the list
                for (int i = 0; i < indexToRemove.Count; i++)
                {
                    rentedVehiclesList.RemoveAt(indexToRemove[i]);
                }

                //Create a List of model type Vehicle accordingly to the Ids list
                List<Vehicle> recommendedVehicles = new List<Vehicle>();
                foreach (var x in vehicles)
                {
                    foreach (var y in rentedVehiclesList)
                    {
                        if(x.VehicleId == y)
                            recommendedVehicles.Add(x);
                    }
                }

                //Order the list by the daily price in descending order
                recommendedVehicles = recommendedVehicles.OrderByDescending(x => x.PriceByDay).ToList();

                //And if the list contains more than 3 vehicles, remove it, and return 3 of the most expensive vehicles to display in the UI 
                if (recommendedVehicles.Count > 3)
                {
                    recommendedVehicles.RemoveRange(3, recommendedVehicles.Count - 3);
                }

                return _mapper.Map<List<VehicleModel>>(recommendedVehicles);
            }

            //If reservation.count == 0 means the client didn't have any reservations yet, and we return the list of every
            // vehicle from the db. We will calculate that accordingly later in the project
            return _mapper.Map<List<OpenRoads.Model.VehicleModel>>(vehicles);
        }
    }
}
