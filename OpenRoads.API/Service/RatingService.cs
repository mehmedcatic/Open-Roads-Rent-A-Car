using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoadsWebAPI.Service
{
    public class RatingService : BaseCRUDService<RatingModel, RatingSearchRequest, Rating, RatingInsertUpdateRequest, RatingInsertUpdateRequest>
    {
        public RatingService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override RatingModel GetById(int id)
        {
            var rating = _context.Ratings.FirstOrDefault(x => x.ReservationId == id);

            if (rating != null)
                return _mapper.Map<RatingModel>(rating);

            return null;
        }
        
    }
}
