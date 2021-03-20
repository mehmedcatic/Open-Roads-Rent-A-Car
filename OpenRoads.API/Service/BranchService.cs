using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoadsWebAPI.Service
{
    public class BranchService : BaseCRUDService<BranchModel, BranchSearchRequest, Branch, BranchInsertUpdateRequest, BranchInsertUpdateRequest>
    {
        public BranchService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override List<BranchModel> Get(BranchSearchRequest search)
        {
            var query = _context.Branches.Where(x => x.Active == true).ToList();
            var countries = _context.Countries.ToList();

            List<Branch> branches = new List<Branch>();

            if (search.CountryId.HasValue)
            {
                foreach (var x in query)
                {
                    if(x.CountryId == search.CountryId)
                        branches.Add(x);
                }

                return _mapper.Map<List<BranchModel>>(branches);
            }

            return _mapper.Map<List<BranchModel>>(query);
        }

        public override BranchModel Delete(int id)
        {
            var entity = _context.Branches.FirstOrDefault(x => x.BranchId == id);

            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }

            return _mapper.Map<BranchModel>(entity);
        }

    }
}
