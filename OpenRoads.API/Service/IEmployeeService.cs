using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoadsWebAPI.Service
{
    public interface IEmployeeService
    {
        List<EmployeeModel> Get(EmployeeSearchRequest search);

        EmployeeModel GetById(int id);

        EmployeeModel Insert(EmployeeInsertUpdateRequest request);

        EmployeeModel Update(int id, EmployeeInsertUpdateRequest request);

        EmployeeModel Delete(int id);

        EmployeeModel AuthenticateEmployee(string username, string password);
    }
}
