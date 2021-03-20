using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenRoadsWebAPI.Service
{
    public interface IBaseService<T, TSearch>
    {
        List<T> Get(TSearch search);

        T GetById(int id);

        T AuthenticateAdmin(string username, string password);

        T AuthenticateClient(string username, string password);
    }
}
