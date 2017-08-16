using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ajf.RideShare.Models.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var passwordHasher = new PasswordHasher();

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppAdmin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "claire@email.dk"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "claire@email.dk" };

                manager.Create(user, "Claire1");
                manager.AddToRole(user.Id, "AppAdmin");
            }
            if (!context.Users.Any(u => u.UserName == "frank@email.dk"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "frank@email.dk" };

                manager.Create(user, "Frank1");
                manager.AddToRole(user.Id, "AppAdmin");
            }

            //var events = new[]
            //{
            //    new Event
            //    {
            //        Description = "First event" + DateTime.Now,
            //        OwnerUserId = users[0].Id,
            //        TimeFrom = DateTime.Now.AddDays(1),
            //        TimeTo = DateTime.Now.AddDays(1).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    },
            //    new Event
            //    {
            //        Description = "Second event" + DateTime.Now,
            //        OwnerUserId = users[1].Id,
            //        TimeFrom = DateTime.Now.AddDays(2),
            //        TimeTo = DateTime.Now.AddDays(2).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    }
            //};

            //context.Users.AddOrUpdate(p => p.Email, users);
            //context.Events.AddOrUpdate(e => e.Description, events);
        }
    }
}