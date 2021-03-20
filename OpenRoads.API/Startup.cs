using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OpenRoads.API.Database;
using OpenRoads.API.Filters;
using OpenRoads.API.Security;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using OpenRoadsWebAPI.Service;
using VehicleModel = OpenRoads.Model.VehicleModel;

namespace OpenRoads.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //DB CONTEXT
            var connection = Configuration.GetConnectionString("cs1");
            services.AddDbContext<openRoadsContext>(x => x.UseSqlServer(connection));



            //AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Enabled custom created filter
            services.AddMvc(x => x.Filters.Add<ErrorFilter>());


            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Open Roads API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);



            //Mapping of the service classes and interfaces

            //Services that implement IBaseCRUD interface
            services
                .AddScoped<IBaseCRUDService<BranchModel, BranchSearchRequest, BranchInsertUpdateRequest,
                    BranchInsertUpdateRequest>, BranchService>();
            services
                .AddScoped<IEmployeeService, EmployeeService>();
            services
                .AddScoped<IBaseCRUDService<ReservationModel, ReservationSearchRequest, ReservationInsertUpdateRequest,
                    ReservationInsertUpdateRequest>, ReservationService>();
            services
                .AddScoped<IBaseCRUDService<RatingModel, RatingSearchRequest, RatingInsertUpdateRequest,
                    RatingInsertUpdateRequest>, RatingService>();
            services
                .AddScoped<IBaseCRUDService<VehicleModel, VehicleSearchRequest, VehicleInsertUpdateRequest,
                    VehicleInsertUpdateRequest>, VehicleService>();
            services
                .AddScoped<IBaseCRUDService<CountryModel, object, CountryInsertRequest, CountryInsertRequest>,
                    BaseCRUDService<CountryModel, object, Country, CountryInsertRequest, CountryInsertRequest>>();
            services
                .AddScoped<
                    IBaseCRUDService<InsuranceModel, object, InsuranceInsertUpdateRequest, InsuranceInsertUpdateRequest>
                    , BaseCRUDService<InsuranceModel, object, Insurance, InsuranceInsertUpdateRequest,
                        InsuranceInsertUpdateRequest>>();
            services
                .AddScoped<IBaseCRUDService<ClientModel, ClientSearchRequest, ClientUpdateRequest, ClientUpdateRequest>,
                    ClientService>();
            services
                .AddScoped<IBaseCRUDService<EmployeeRolesModel, object, EmployeeRolesInsertUpdateRequest,
                        EmployeeRolesInsertUpdateRequest>,
                    BaseCRUDService<EmployeeRolesModel, object, EmployeeRole, EmployeeRolesInsertUpdateRequest,
                        EmployeeRolesInsertUpdateRequest>>();
            services
                .AddScoped<
                    IBaseCRUDService<VehicleCategoryModel, object, VehicleReferenceTableAddUpdateRequest,
                        VehicleReferenceTableAddUpdateRequest>, BaseCRUDService<VehicleCategoryModel, object,
                        VehicleCategory, VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>>();
            services
                .AddScoped<
                    IBaseCRUDService<VehicleFuelTypeModel, object, VehicleReferenceTableAddUpdateRequest,
                        VehicleReferenceTableAddUpdateRequest>, BaseCRUDService<VehicleFuelTypeModel, object,
                        VehicleFuelType, VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>>();
            services
                .AddScoped<IBaseCRUDService<VehicleManufacturerModel, object, VehicleReferenceTableAddUpdateRequest,
                        VehicleReferenceTableAddUpdateRequest>,
                    BaseCRUDService<VehicleManufacturerModel, object, VehicleManufacturer,
                        VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>>();
            services
                .AddScoped<IBaseCRUDService<VehicleTransmissionTypeModel, object, VehicleReferenceTableAddUpdateRequest,
                        VehicleReferenceTableAddUpdateRequest>,
                    BaseCRUDService<VehicleTransmissionTypeModel, object, VehicleTransmissionType,
                        VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>>();
            services
                .AddScoped<
                    IBaseCRUDService<VehicleTypeModel, object, VehicleReferenceTableAddUpdateRequest,
                        VehicleReferenceTableAddUpdateRequest>, BaseCRUDService<VehicleTypeModel, object, VehicleType,
                        VehicleReferenceTableAddUpdateRequest, VehicleReferenceTableAddUpdateRequest>>();
            services
                .AddScoped<IBaseCRUDService<VehicleModelModel, VehicleModelSearchRequest, VehicleModelAddUpdateRequest,
                    VehicleModelAddUpdateRequest>, VehicleModelService>();
            services
                .AddScoped<IBaseCRUDService<LoginDataModel, object, LoginDataInsertUpdateRequest,
                    LoginDataInsertUpdateRequest>, LoginDataService>();
            services
                .AddScoped<IBaseCRUDService<PersonModel, object, PersonInsertUpdateRequest, PersonInsertUpdateRequest>,
                    PersonService>();

            //Services that implement IBase interface
            services
                .AddScoped<IBaseService<EmployeeEmployeeRolesModel, object>, EmployeeEmployeeRolesService>();


            //Recommender service
            services.AddScoped<IRecommenderService, RecommenderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
