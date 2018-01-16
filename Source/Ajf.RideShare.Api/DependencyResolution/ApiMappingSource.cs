using System.Data.Entity;
using Ajf.RideShare.Models;
using Highway.Data;

namespace Ajf.RideShare.Api.DependencyResolution
{
    public class ApiMappingSource : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>();
            modelBuilder.Entity<Car>();
        }
    }
}