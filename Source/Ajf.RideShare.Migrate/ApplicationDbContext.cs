using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ajf.RideShare.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("RideShareConnection")
        {
        }

        public static void UpdateDatabase()
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public DbSet<Event> Events { get; set; }
        //public DbSet<Car> Cars { get; set; }
        //public DbSet<Passenger> Passengers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Guid UserSub { get; set; }
    }
}