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
    public class PersonService : BaseCRUDService<PersonModel, object, Person, PersonInsertUpdateRequest, PersonInsertUpdateRequest>
    {
        public PersonService(openRoadsContext context, IMapper mapper) : base(context, mapper)
        {
        }


    }
}
