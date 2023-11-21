using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace WashingCarDB.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //La siguiente línea comtrola la duplicidad de los países
            //modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();

            //modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            //modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique();//Indice compuesto
            //modelBuilder.Entity<City>().HasIndex("Name", "StateId").IsUnique();//Indice compuesto

        }

    }
}
