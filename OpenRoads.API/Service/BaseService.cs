using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;

namespace OpenRoadsWebAPI.Service
{
    public class BaseService<TModel, TSearch, TDatabase> : IBaseService<TModel, TSearch> where TDatabase : class
    {
        protected readonly openRoadsContext _context;
        protected readonly IMapper _mapper;

        public BaseService(openRoadsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public virtual List<TModel> Get(TSearch search)
        {
            var list = _context.Set<TDatabase>().ToList();

            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel AuthenticateAdmin(string username, string password)
        {
            var entity = _context.Set<TDatabase>().Find(username);

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel AuthenticateClient(string username, string password)
        {
            var entity = _context.Set<TDatabase>().Find(username);

            return _mapper.Map<TModel>(entity);
        }
    }
}
