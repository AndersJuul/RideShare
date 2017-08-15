using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;

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

            var users = new[]
            {
                new ApplicationUser
                {
                    Email = "frank@email.dk",
                    UserName = "frank",
                    PasswordHash = passwordHasher.HashPassword("Frank1")
                },
                new ApplicationUser
                {
                    Email = "claire@email.dk",
                    UserName = "claire",
                    PasswordHash = passwordHasher.HashPassword("Claire1")
                }
            };

            var events = new[]
            {
                new Event
                {
                    Description = "First event" + DateTime.Now,
                    OwnerUserId = users[0].Id,
                    TimeFrom = DateTime.Now.AddDays(1),
                    TimeTo = DateTime.Now.AddDays(1).AddHours(1),
                    CreateTime = DateTime.Now,
                    Cars = new Collection<Car>(),
                    Passengers = new Collection<Passenger>()
                },
                new Event
                {
                    Description = "Second event" + DateTime.Now,
                    OwnerUserId = users[1].Id,
                    TimeFrom = DateTime.Now.AddDays(2),
                    TimeTo = DateTime.Now.AddDays(2).AddHours(1),
                    CreateTime = DateTime.Now,
                    Cars = new Collection<Car>(),
                    Passengers = new Collection<Passenger>()
                }
            };

            context.Users.AddOrUpdate(p => p.Email, users);
            context.Events.AddOrUpdate(e => e.Description, events);
        }
    }
}