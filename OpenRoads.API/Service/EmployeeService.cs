using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.API.Exceptions;
using OpenRoads.API.Helpers;
using OpenRoads.Model;
using OpenRoads.Model.Requests;

namespace OpenRoadsWebAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly openRoadsContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(openRoadsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public EmployeeModel AuthenticateEmployee(string username, string password)
        {
            var loginDataUser = _context.LoginData.FirstOrDefault(x => x.Username == username);
            var person = _context.People.FirstOrDefault(x => x.LoginDataId == loginDataUser.LoginDataId);
            var employee = _context.Employees.FirstOrDefault(x => x.PersonId == person.PersonId);
         
            if (employee != null)
            {
                var newHash = HelperClass.GenerateHash(loginDataUser.PasswordSalt, password);

                if (newHash == loginDataUser.PasswordHash)
                {
                    return _mapper.Map<EmployeeModel>(employee);
                }
            }

            return null;

        }

        public List<EmployeeModel> Get(EmployeeSearchRequest search)
        {
            var query = _context.Employees.Where(x => x.Active == true).ToList();
            var emplEmplRoles = _context.EmployeeEmployeeRoles.ToList();

            List<Employee> listEmpl = new List<Employee>();

            if (search.EmployeeRolesId.HasValue && search.BranchId.HasValue)
            {
                foreach (var x in emplEmplRoles)
                {
                    foreach (var y in query)
                    {
                        if (x.EmployeeRolesId == search.EmployeeRolesId && x.EmployeeId == y.EmployeeId)
                        {
                            if (search.BranchId == y.BranchId)
                                listEmpl.Add(y);
                        }
                    }
                }

                return _mapper.Map<List<EmployeeModel>>(listEmpl);
            }
            if (search.EmployeeRolesId.HasValue && search.BranchId.HasValue == false)
            {
                foreach (var x in emplEmplRoles)
                {
                    foreach (var y in query)
                    {
                        if (x.EmployeeRolesId == search.EmployeeRolesId && x.EmployeeId == y.EmployeeId)
                            listEmpl.Add(y);
                    }
                }
                return _mapper.Map<List<EmployeeModel>>(listEmpl);
            }

            if (search.EmployeeRolesId.HasValue == false && search.BranchId.HasValue)
            {
                foreach (var x in query)
                {
                    if (x.BranchId == search.BranchId)
                        listEmpl.Add(x);
                }

                return _mapper.Map<List<EmployeeModel>>(listEmpl);
            }

            if (!string.IsNullOrEmpty(search.Username))
            {
                var persons = _context.People.ToList();
                var loginModel = _context.LoginData.FirstOrDefault(x => x.Username == search.Username);

                List<EmployeeModel> employee = new List<EmployeeModel>();
                foreach (var x in query)
                {
                    foreach (var person in persons)
                    {
                        if (x.PersonId == person.PersonId)
                        {
                            if (person.LoginDataId == loginModel.LoginDataId && loginModel.Username == search.Username)
                                employee.Add(new EmployeeModel
                                {
                                    PersonId = x.PersonId,
                                    Active = x.Active,
                                    BranchId = x.BranchId,
                                    EmployeeCode = x.EmployeeCode,
                                    EmployeeId = x.EmployeeId,
                                    HireDate = x.HireDate,
                                    JobDescription = x.JobDescription
                                });
                            break;
                        }
                    }
                }

                if (employee.Count > 0)
                    return _mapper.Map<System.Collections.Generic.List<EmployeeModel>>(employee);

                return null;


            }
            return _mapper.Map<List<EmployeeModel>>(query);

        }

        public EmployeeModel GetById(int id)
        {
            var entity = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);

            return _mapper.Map<EmployeeModel>(entity);
        }

        public EmployeeModel Insert(EmployeeInsertUpdateRequest request)
        {
            var LoginDataCheck = _context.LoginData.FirstOrDefault(x => x.Username == request.Username);
            if (LoginDataCheck != null)
                throw new UserException("Username already exists, try another one!");
            
            var personCheck = _context.People.FirstOrDefault(x => x.Email == request.Email);
            if(personCheck != null)
                throw new UserException("Email already exists, try another one!");

            request.PasswordSalt = HelperClass.GenerateSalt();
            request.PasswordHash = HelperClass.GenerateHash(request.PasswordSalt, request.CleasPassword);

            LoginData newData = new LoginData
            {
                Username = request.Username,
                PasswordSalt = request.PasswordSalt,
                PasswordHash = request.PasswordHash
            };

            _context.LoginData.Add(newData);
            _context.SaveChanges();


            Person newPerson = new Person
            {
                Address = request.Address,
                City = request.City,
                CountryId = request.CountryId,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                LoginDataId = newData.LoginDataId
            };

            _context.Add(newPerson);
            _context.SaveChanges();


            Employee newEmployee = new Employee
            {
                Active = request.Active,
                BranchId = request.BranchId,
                EmployeeCode = request.EmployeeCode,
                HireDate = request.HireDate,
                PersonId = newPerson.PersonId,
                JobDescription = request.JobDescription
            };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();


            EmployeeEmployeeRole newEmployeeRoles = new EmployeeEmployeeRole
            {
                ChangeDate = DateTime.Now,
                EmployeeRolesId = request.EmployeeRoleId,
                EmployeeId = newEmployee.EmployeeId
            };

            _context.EmployeeEmployeeRoles.Add(newEmployeeRoles);
            _context.SaveChanges();

            return _mapper.Map<EmployeeModel>(newEmployee);


        }

        public EmployeeModel Update(int id, EmployeeInsertUpdateRequest request)
        {
            Employee employeeObj = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            var loginDataList = _context.LoginData.ToList();
            var personList = _context.People.ToList();

            foreach (var x in loginDataList)
            {
                foreach (var y in personList)
                {
                    if (y.PersonId == employeeObj.PersonId && x.LoginDataId == y.LoginDataId)
                    {
                        if (x.Username == "adminDesktop" || x.Username == "branchEmployeeDesktop")
                        {
                            throw new UserException("This asset cannot be updated!");
                        }

                        break;
                    }
                }
            }

            if (employeeObj != null)
            {
                employeeObj.BranchId = request.BranchId;
                employeeObj.EmployeeCode = request.EmployeeCode;
                employeeObj.JobDescription = request.JobDescription;
                employeeObj.Active = request.Active;
                employeeObj.HireDate = request.HireDate;
            }


            Person personObj = _context.People.FirstOrDefault(x => x.PersonId == employeeObj.PersonId);
            if (personObj != null)
            {
                personObj.FirstName = request.FirstName;
                personObj.LastName = request.LastName;
                personObj.DateOfBirth = request.DateOfBirth;
                personObj.City = request.City;
                personObj.CountryId = request.CountryId;
                personObj.Address = request.Address;
                personObj.Email = request.Email;
                personObj.PhoneNumber = request.PhoneNumber;
            }


            request.PasswordSalt = HelperClass.GenerateSalt();
            request.PasswordHash = HelperClass.GenerateHash(request.PasswordSalt, request.CleasPassword);
            LoginData loginDataObj = _context.LoginData.FirstOrDefault(x => x.LoginDataId == personObj.LoginDataId);
            if (loginDataObj != null)
            {
                loginDataObj.Username = request.Username;
                loginDataObj.PasswordSalt = request.PasswordSalt;
                loginDataObj.PasswordHash = request.PasswordHash;
            }




            EmployeeEmployeeRole emplEmplRolesObj =
                _context.EmployeeEmployeeRoles.FirstOrDefault(x => x.EmployeeId == employeeObj.EmployeeId);
            if (emplEmplRolesObj != null)
            {
                emplEmplRolesObj.EmployeeRolesId = request.EmployeeRoleId;
                emplEmplRolesObj.ChangeDate = DateTime.Now;
            }


            _context.SaveChanges();
            return _mapper.Map<EmployeeModel>(employeeObj);

        }

        public EmployeeModel Delete(int id)
        {
            var entity = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            var loginDataList = _context.LoginData.ToList();
            var personList = _context.People.ToList();

            foreach (var x in loginDataList)
            {
                foreach (var y in personList)
                {
                    if (y.PersonId == entity.PersonId && x.LoginDataId == y.LoginDataId)
                    {
                        if (x.Username == "adminDesktop" || x.Username == "branchEmployeeDesktop")
                        {
                            throw new UserException("This asset cannot be removed!");
                        }

                        break;
                    }
                }
            }

            if (entity != null)
            {
                entity.Active = false;
                _context.SaveChanges();
            }

            return _mapper.Map<EmployeeModel>(entity);

        }

    }
}
