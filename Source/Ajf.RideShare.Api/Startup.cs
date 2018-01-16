using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IdentityModel.Tokens;
using System.Web.Http;
using Ajf.Nuget.Logging;
using Ajf.RideShare.Api.DependencyResolution;
using IdentityServer3.AccessTokenValidation;
using Owin;
using Serilog;

namespace Ajf.RideShare.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Log.Logger = StandardLoggerConfigurator
                .GetLoggerConfig().MinimumLevel
                .Debug()
                .CreateLogger();

            Log.Logger.Information("Starting...");
            Log.Logger.Information("Version is... " + ConfigurationManager.AppSettings["ReleaseNumber"]);

            // setup http configuration
            var httpConfig = new HttpConfiguration();

            //configure dependency injection
            var container = IoC.Initialize();
            container.AssertConfigurationIsValid();
            Debug.WriteLine(container.WhatDoIHave());
            Log.Logger.Debug(container.WhatDoIHave());
            httpConfig.DependencyResolver = new StructureMapWebApiDependencyResolver(container);

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = ConfigurationManager.AppSettings["IdentityServerApplicationUrl"],
                    RequiredScopes = new[] {"gallerymanagement"}
                });

            WebApiConfig.Register(httpConfig);
            app.UseWebApi(httpConfig);

            AutoMapperInitializor.Init();
        }
    }
}