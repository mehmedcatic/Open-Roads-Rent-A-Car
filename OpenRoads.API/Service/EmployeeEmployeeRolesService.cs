using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model;

namespace OpenRoadsWebAPI.Service
{
    public class EmployeeEmployeeRolesService : BaseService<EmployeeEmployeeRolesModel, object, EmployeeEmployeeRole>
    {
        public EmployeeEmployeeRolesService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override EmployeeEmployeeRolesModel GetById(int id)
        {
            return _mapper.Map<EmployeeEmployeeRolesModel>(
                _context.EmployeeEmployeeRoles.FirstOrDefault(x => x.EmployeeId == id));
        }
    }
}
