using System.Configuration;
using Highway.Data;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Ajf.RideShare.Api.DependencyResolution
{
    public class ApiRegistry : Registry
    {
        #region Constructors and Destructors

        public ApiRegistry()
        {
            var apiMappingSource = new ApiMappingSource();
            var connectionString = ConfigurationManager.ConnectionStrings["RideShareConnection"].ConnectionString;
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
            For<IRepository>()
                .Use(x => new Repository(new DataContext(
                    connectionString,
                    apiMappingSource)));
        }

        #endregion
    }
}