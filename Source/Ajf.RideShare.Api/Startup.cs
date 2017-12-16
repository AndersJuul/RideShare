using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using Ajf.RideShare.Models;
using AutoMapper;
using IdentityServer3.AccessTokenValidation;
using Owin;
using TripGallery.API;
using TripGallery.API.Helpers;
using TripGallery.DTO;
using Picture = TripGallery.Repository.Entities.Picture;
using Trip = TripGallery.Repository.Entities.Trip;

namespace Ajf.RideShare.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
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
                cfg.CreateMap<PictureForCreation,
                        Picture>()
                    .ForMember(o => o.Id, o => o.Ignore())
                    .ForMember(o => o.TripId, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore())
                    .ForMember(o => o.Uri, o => o.Ignore());


                cfg.CreateMap<TripForCreation,
                        Trip>()
                    .ForMember(o => o.Id, o => o.Ignore())
                    .ForMember(o => o.MainPictureUri, o => o.Ignore())
                    .ForMember(o => o.Pictures, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore());

                cfg.CreateMap<EventForCreation, Event>()
                    .ForMember(o => o.EventId, o => o.Ignore())
                    .ForMember(o => o.OwnerId, o => o.Ignore());

            });
            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}