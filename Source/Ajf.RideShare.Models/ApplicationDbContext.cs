using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ajf.RideShare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("RideShareConnection", throwIfV1Schema: false)
        {
        }

        public static void UpdateDatabase()
        {
            Database.SetInitializer<ApplicationDbContext>(null);

            //var settings = new Migrations.Configuration();
            //var migrator = new DbMigrator(settings);
            //migrator.Update();

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}