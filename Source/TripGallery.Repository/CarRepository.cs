using System;
using Ajf.RideShare.Models;

namespace TripGallery.Repository
{
    public class CarRepository : ICarRepository
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
        }

        public void AddCar(Car car)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Cars.Add(car);

                db.SaveChanges();
            }
        }
    }
}