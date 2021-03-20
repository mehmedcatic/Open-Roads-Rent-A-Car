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
    public class LoginDataService : BaseCRUDService<LoginDataModel, object, LoginData, LoginDataInsertUpdateRequest, LoginDataInsertUpdateRequest>
    {
        public LoginDataService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        
    }
}
