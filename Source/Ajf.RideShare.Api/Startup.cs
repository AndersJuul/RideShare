using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using Ajf.Nuget.Logging;
using Ajf.RideShare.Api.App_Start;
using Ajf.RideShare.Models;
using AutoMapper;
using IdentityServer3.AccessTokenValidation;
using Owin;
using Serilog;
using TripGallery.API;
using TripGallery.DTO;
using Picture = TripGallery.Repository.Entities.Picture;
using Trip = TripGallery.Repository.Entities.Trip;

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
            Log.Logger.Information("Version is... " + ConfigurationManager.AppSettings["ReleaseNumber"] );

            StructuremapWebApi.Start();

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(
                new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = ConfigurationManager.AppSettings["IdentityServerApplicationUrl"],
                    RequiredScopes = new[] {"gallerymanagement"}
                });

            var config = WebApiConfig.Register();

            app.UseWebApi(config);


            InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<EventForCreation, Event>()
                    .ForMember(o => o.Cars, o => o.Ignore())
                    .ForMember(o => o.EventId, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore());

            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}