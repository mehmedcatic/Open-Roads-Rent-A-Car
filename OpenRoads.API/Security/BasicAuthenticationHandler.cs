using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoadsWebAPI.Service;

namespace OpenRoads.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IEmployeeService _adminService;

        private readonly IBaseCRUDService<ClientModel, ClientSearchRequest, ClientUpdateRequest, ClientUpdateRequest>
            _clientService;

        private readonly openRoadsContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IEmployeeService adminService,
            IBaseCRUDService<ClientModel, ClientSearchRequest, ClientUpdateRequest, ClientUpdateRequest> clientService,
            openRoadsContext context)
            : base(options, logger, encoder, clock)
        {
            _adminService = adminService;
            _clientService = clientService;
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            EmployeeModel admin = null;
            ClientModel client = null;
            LoginData loginDataPerson = null;
            Person person = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                admin = _adminService.AuthenticateEmployee(username, password);
                client = _clientService.AuthenticateClient(username, password);
                loginDataPerson = _context.LoginData.FirstOrDefault(x => x.Username == username);
                person = _context.People.FirstOrDefault(x => x.LoginDataId == loginDataPerson.LoginDataId);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (admin == null && client == null)
                return AuthenticateResult.Fail("Invalid Username or Password");




            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, loginDataPerson.Username),
                new Claim(ClaimTypes.Name, person.FirstName),
            };


            if (admin != null)
            {
                var employeeRoles = _context.EmployeeRoles.ToList();
                var employeeRolesList = _context.EmployeeEmployeeRoles.ToList();

                foreach (var x in employeeRolesList)
                {
                    if (admin.EmployeeId == x.EmployeeId)
                    {
                        foreach (var y in employeeRoles)
                        {
                            if (x.EmployeeRolesId == y.EmployeeRolesId)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, y.Name));
                            }
                        }

                        break;
                    }
                }
            }

            if (client != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Client"));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
