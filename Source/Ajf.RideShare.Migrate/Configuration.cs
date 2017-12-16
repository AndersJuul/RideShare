using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using Ajf.RideShare.Models;

namespace Ajf.RideShare.Migrate
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //_frankEmailDk = "frank@email.dk";
            //_claireEmailDk = "claire@email.dk";

            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "AppAdmin" };

            //    manager.Create(role);
            //}

            //if (!context.Users.Any(u => u.UserName == _claireEmailDk))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = _claireEmailDk };

            //    manager.Create(user, "Claire1");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}
            //if (!context.Users.Any(u => u.UserName == _frankEmailDk))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = _frankEmailDk };

            //    manager.Create(user, "Frank1");
            //    manager.AddToRole(user.Id, "AppAdmin");
            //}

            //var userFrank = context.Users.Single(u => u.UserName == _frankEmailDk);

            //var events = new[]
            //{
            //    new Event
            //    {
            //        Description = "First event" + DateTime.Now,
            //        OwnerUserId = userFrank.Id,
            //        TimeFrom = DateTime.Now.AddDays(1),
            //        TimeTo = DateTime.Now.AddDays(1).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    },
            //    new Event
            //    {
            //        Description = "Second event" + DateTime.Now,
            //        OwnerUserId = userFrank.Id,
            //        TimeFrom = DateTime.Now.AddDays(2),
            //        TimeTo = DateTime.Now.AddDays(2).AddHours(1),
            //        CreateTime = DateTime.Now,
            //        Cars = new Collection<Car>(),
            //        Passengers = new Collection<Passenger>()
            //    }
            //};

            //context.Events.AddOrUpdate(e => e.Description, events);
        }
    }
}