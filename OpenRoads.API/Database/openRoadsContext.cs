using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OpenRoads.API.Database
{
    public partial class openRoadsContext : DbContext
    {
        public openRoadsContext()
        {
        }

        public openRoadsContext(DbContextOptions<openRoadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeEmployeeRole> EmployeeEmployeeRoles { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<LoginData> LoginData { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleCategory> VehicleCategories { get; set; }
        public virtual DbSet<VehicleFuelType> VehicleFuelTypes { get; set; }
        public virtual DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }
        public virtual DbSet<VehicleModel> VehicleModels { get; set; }
        public virtual DbSet<VehicleTransmissionType> VehicleTransmissionTypes { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=openRoads;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.HasIndex(e => e.CountryId, "IX_Branch_CountryId");

                entity.Property(e => e.Zipcode).HasColumnName("ZIPCode");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.PersonId, "IX_Client_PersonId");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.BranchId, "IX_Employee_BranchId");

                entity.HasIndex(e => e.PersonId, "IX_Employee_PersonId");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmployeeEmployeeRole>(entity =>
            {
                entity.HasKey(e => e.EmployeeEmployeeRolesId);

                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeEmployeeRoles_EmployeeId");

                entity.HasIndex(e => e.EmployeeRolesId, "IX_EmployeeEmployeeRoles_EmployeeRolesId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeEmployeeRoles)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EmployeeRoles)
                    .WithMany(p => p.EmployeeEmployeeRoles)
                    .HasForeignKey(d => d.EmployeeRolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.HasKey(e => e.EmployeeRolesId);
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");
            });

            modelBuilder.Entity<LoginData>(entity =>
            {
                entity.HasKey(e => e.LoginDataId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.HasIndex(e => e.CountryId, "IX_Person_CountryId");

                entity.HasIndex(e => e.LoginDataId, "IX_Person_LoginDataId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LoginData)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.LoginDataId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.HasIndex(e => e.ClientId, "IX_Rating_ClientId");

                entity.HasIndex(e => e.ReservationId, "IX_Rating_ReservationId");

                entity.HasIndex(e => e.VehicleId, "IX_Rating_VehicleId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation");

                entity.HasIndex(e => e.ClientId, "IX_Reservation_ClientId");

                entity.HasIndex(e => e.InsuranceId, "IX_Reservation_InsuranceId");

                entity.HasIndex(e => e.VehicleId, "IX_Reservation_VehicleId");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.HasIndex(e => e.BranchId, "IX_Vehicle_BranchId");

                entity.HasIndex(e => e.VehicleCategoryId, "IX_Vehicle_VehicleCategoryId");

                entity.HasIndex(e => e.VehicleFuelTypeId, "IX_Vehicle_VehicleFuelTypeId");

                entity.HasIndex(e => e.VehicleModelId, "IX_Vehicle_VehicleModelId");

                entity.HasIndex(e => e.VehicleTransmissionTypeId, "IX_Vehicle_VehicleTransmissionTypeId");

                entity.HasIndex(e => e.VehicleTypeId, "IX_Vehicle_VehicleTypeId");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleCategory)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleFuelType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleFuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleModel)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleTransmissionType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTransmissionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.VehicleType)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<VehicleCategory>(entity =>
            {
                entity.ToTable("VehicleCategory");
            });

            modelBuilder.Entity<VehicleFuelType>(entity =>
            {
                entity.ToTable("VehicleFuelType");
            });

            modelBuilder.Entity<VehicleManufacturer>(entity =>
            {
                entity.ToTable("VehicleManufacturer");
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.ToTable("VehicleModel");

                entity.HasIndex(e => e.VehicleManufacturerId, "IX_VehicleModel_VehicleManufacturerId");

                entity.HasOne(d => d.VehicleManufacturer)
                    .WithMany(p => p.VehicleModels)
                    .HasForeignKey(d => d.VehicleManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<VehicleTransmissionType>(entity =>
            {
                entity.ToTable("VehicleTransmissionType");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
