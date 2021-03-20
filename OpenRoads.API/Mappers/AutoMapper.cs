using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OpenRoads.API.Database;
using OpenRoads.Model;
using OpenRoads.Model.Requests;
using VehicleModel = OpenRoads.API.Database.VehicleModel;

namespace OpenRoads.API.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Branch, BranchModel>().ReverseMap();
            CreateMap<BranchInsertUpdateRequest, Branch>().ReverseMap();


            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<ClientUpdateRequest, Client>().ReverseMap();


            CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<CountryInsertRequest, Country>().ReverseMap();


            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<EmployeeInsertUpdateRequest, Employee>().ReverseMap();


            CreateMap<EmployeeEmployeeRole, EmployeeEmployeeRolesModel>().ReverseMap();
            CreateMap<EmployeeRolesInsertUpdateRequest, EmployeeRole>().ReverseMap();


            CreateMap<EmployeeRole, EmployeeRolesModel>().ReverseMap();


            CreateMap<Insurance, InsuranceModel>().ReverseMap();
            CreateMap<InsuranceInsertUpdateRequest, Insurance>().ReverseMap();


            CreateMap<LoginData, LoginDataModel>().ReverseMap();
            CreateMap<LoginDataInsertUpdateRequest, LoginData>().ReverseMap();


            CreateMap<Person, PersonModel>().ReverseMap();
            CreateMap<PersonInsertUpdateRequest, Person>().ReverseMap();


            CreateMap<Rating, RatingModel>().ReverseMap();
            CreateMap<RatingInsertUpdateRequest, Rating>().ReverseMap();


            CreateMap<Reservation, ReservationModel>().ReverseMap();
            CreateMap<ReservationInsertUpdateRequest, Reservation>().ReverseMap();


            CreateMap<Vehicle, OpenRoads.Model.VehicleModel>().ReverseMap();
            CreateMap<VehicleInsertUpdateRequest, Vehicle>().ReverseMap();
            CreateMap<Vehicle, Vehicle>();


            CreateMap<VehicleCategory, VehicleCategoryModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleCategory>().ReverseMap();


            CreateMap<VehicleFuelType, VehicleFuelTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleFuelType>().ReverseMap();


            CreateMap<VehicleManufacturer, VehicleManufacturerModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleManufacturer>().ReverseMap();


            CreateMap<VehicleModel, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelAddUpdateRequest, VehicleModel>().ReverseMap();


            CreateMap<VehicleTransmissionType, VehicleTransmissionTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleTransmissionType>().ReverseMap();


            CreateMap<VehicleType, VehicleTypeModel>().ReverseMap();
            CreateMap<VehicleReferenceTableAddUpdateRequest, VehicleType>().ReverseMap();


        }
    }
}
