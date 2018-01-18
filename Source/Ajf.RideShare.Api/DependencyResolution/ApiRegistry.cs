using System.Configuration;
using Highway.Data;
using StructureMap;
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
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["RideShareConnection"];
            var connectionString = connectionStringSettings != null ? connectionStringSettings.ConnectionString : "Server=JuulServer2017;Database=RideShare.Web-DEV;User Id=rideshare;Password=rideshare";
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