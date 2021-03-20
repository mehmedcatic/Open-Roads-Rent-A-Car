using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OpenRoads.API.Database
{
    public partial class openRoadsContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Country>().HasData(Helpers.HelperClass.LoadJsonFromFile<Country>
                ("CountryJson.json"));

            modelBuilder.Entity<VehicleCategory>().HasData(Helpers.HelperClass.LoadJsonFromFile<VehicleCategory>
                ("VehicleCategoryJson.json"));

            modelBuilder.Entity<VehicleFuelType>().HasData(Helpers.HelperClass.LoadJsonFromFile<VehicleFuelType>
                ("VehicleFuelTypeJson.json"));

            modelBuilder.Entity<VehicleManufacturer>().HasData(Helpers.HelperClass.LoadJsonFromFile<VehicleManufacturer>
                ("VehicleManufacturerJson.json"));

            modelBuilder.Entity<VehicleTransmissionType>().HasData(
                Helpers.HelperClass.LoadJsonFromFile<VehicleTransmissionType>
                    ("VehicleTransmissionTypeJson.json"));

            modelBuilder.Entity<VehicleType>().HasData(Helpers.HelperClass.LoadJsonFromFile<VehicleType>
                ("VehicleTypeJson.json"));

            modelBuilder.Entity<VehicleModel>().HasData(Helpers.HelperClass.LoadJsonFromFile<VehicleModel>
                ("VehicleModelJson.json"));

            modelBuilder.Entity<Insurance>().HasData(Helpers.HelperClass.LoadJsonFromFile<Insurance>
                ("InsuranceJson.json"));

            modelBuilder.Entity<EmployeeRole>().HasData(Helpers.HelperClass.LoadJsonFromFile<EmployeeRole>
                ("EmployeeRolesJson.json"));

            modelBuilder.Entity<LoginData>().HasData(Helpers.HelperClass.LoadJsonFromFile<LoginData>
                ("LoginDataJson.json"));

            modelBuilder.Entity<Person>().HasData(Helpers.HelperClass.LoadJsonFromFile<Person>
                ("PersonJson.json"));

            modelBuilder.Entity<Branch>().HasData(Helpers.HelperClass.LoadJsonFromFile<Branch>
                ("BranchJson.json"));

            modelBuilder.Entity<Employee>().HasData(Helpers.HelperClass.LoadJsonFromFile<Employee>
                ("EmployeeJson.json"));


            modelBuilder.Entity<Client>().HasData(Helpers.HelperClass.LoadJsonFromFile<Client>
                ("ClientJson.json"));

            modelBuilder.Entity<EmployeeEmployeeRole>().HasData(
                Helpers.HelperClass.LoadJsonFromFile<EmployeeEmployeeRole>
                    ("EmployeeEmployeeRolesJson.json"));

            modelBuilder.Entity<Vehicle>().HasData(Helpers.HelperClass.LoadJsonFromFile<Vehicle>
                ("VehicleJson.json"));

            modelBuilder.Entity<Reservation>().HasData(Helpers.HelperClass.LoadJsonFromFile<Reservation>
                ("ReservationJson.json"));

            modelBuilder.Entity<Rating>().HasData(Helpers.HelperClass.LoadJsonFromFile<Rating>
                ("RatingJson.json"));

        }
    }
}

