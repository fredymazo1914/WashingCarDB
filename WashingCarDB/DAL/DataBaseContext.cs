using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WashingCarDB.DAL.Entities;

namespace WashingCarDB.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        #region Properties
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDetails> VehiclesDetails { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //La siguiente línea comtrola la duplicidad de los países
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();//Indice compuesto
            //modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();//Indice compuesto
            modelBuilder.Entity<Service>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(v => v.Id).IsUnique();
            modelBuilder.Entity<VehicleDetails>().HasIndex(v => v.Id).IsUnique();

        }

    }
}
