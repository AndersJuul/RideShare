using System.Data.Entity;

namespace Ajf.RideShare.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("RideShareConnection")
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}