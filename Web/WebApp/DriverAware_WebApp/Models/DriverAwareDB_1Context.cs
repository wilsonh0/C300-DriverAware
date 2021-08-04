using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DriverAware_WebApp.Models
{


    public partial class DriverAwareDB_1Context : DbContext
    {
        public DriverAwareDB_1Context()
        {
        }

        public DriverAwareDB_1Context(DbContextOptions<DriverAwareDB_1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<RecordedIncident> RecordedIncidents { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<UserLogIn> UserLogIns { get; set; }
        public DbSet<DriverAware_WebApp.Models.RecordedIncident> RecordedIncident { get; set; }
        public DbSet<DriverAware_WebApp.Models.Driver> Driver { get; set; }
        public DbSet<DriverAware_WebApp.Models.Shift> Shift { get; set; }
        public DbSet<DriverAware_WebApp.Models.Vehicle> Vehicle { get; set; }
        public DbSet<DriverAware_WebApp.Models.Company> Company { get; set; }
        public DbSet<DriverAware_WebApp.Models.UserLogIn> UserLogIn { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Eun)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EUN");

                entity.Property(e => e.IncorporationDate).HasColumnType("date");

                entity.Property(e => e.RegisteredOffice).IsRequired();

                entity.Property(e => e.TradingAs)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.EmployeeNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.GivenName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OtherNames).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Drivers)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Driver");
            });

            modelBuilder.Entity<RecordedIncident>(entity =>
            {
                entity.ToTable("RecordedIncident");

                entity.Property(e => e.Gpslat).HasColumnName("GPSLat");

                entity.Property(e => e.Gpslong).HasColumnName("GPSLong");

                entity.Property(e => e.IncidentTime).HasColumnType("datetime");

                entity.Property(e => e.IncidentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.InverseShift)
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shift_Incident");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.EndDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.EndLocation).HasMaxLength(50);

                entity.Property(e => e.StartDateTime).HasColumnType("smalldatetime");

                entity.Property(e => e.StartLocation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Driver_Shift");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicle_Shift");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RegistrationNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SwVersion)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UnitNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Vehicle");
            });

            modelBuilder.Entity<UserLogIn>(entity =>
            {
                entity.ToTable("UserLogIn");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                       .IsRequired()
                       .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
