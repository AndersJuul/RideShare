using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using AutoMapper;
using IdentityServer3.AccessTokenValidation;
using Owin;
using TripGallery.API;
using TripGallery.API.Helpers;

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
                 Authority =ConfigurationManager.AppSettings["IdentityServerApplicationUrl"] ,
                 RequiredScopes = new[] { "gallerymanagement" },
             });
            
            var config = WebApiConfig.Register();
            
            app.UseWebApi(config);

            InitAutoMapper();
        }

        private void InitAutoMapper()
        {
            Mapper.CreateMap<TripGallery.Repository.Entities.Trip,
                TripGallery.DTO.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(InjectImageBaseForTripResolver)));

            Mapper.CreateMap<TripGallery.Repository.Entities.Picture,
                TripGallery.DTO.Picture>()
                .ForMember(dest => dest.Uri,
                op => op.ResolveUsing(typeof(InjectImageBaseForPictureResolver)));

            Mapper.CreateMap<TripGallery.DTO.Picture,
              TripGallery.Repository.Entities.Picture>();
        

            Mapper.CreateMap<TripGallery.DTO.Trip,
                TripGallery.Repository.Entities.Trip>().ForMember(dest => dest.MainPictureUri,
                op => op.ResolveUsing(typeof(RemoveImageBaseForTripResolver))); ;

            Mapper.CreateMap<TripGallery.DTO.PictureForCreation,
                TripGallery.Repository.Entities.Picture>()
                .ForMember(o => o.Id, o => o.Ignore())
                .ForMember(o => o.TripId, o => o.Ignore())
                .ForMember(o => o.OwnerId, o => o.Ignore())
                .ForMember(o => o.Uri, o => o.Ignore());


            Mapper.CreateMap<TripGallery.DTO.TripForCreation,
         TripGallery.Repository.Entities.Trip>()
            .ForMember(o => o.Id, o => o.Ignore())
            .ForMember(o => o.MainPictureUri, o => o.Ignore())
            .ForMember(o => o.Pictures, o => o.Ignore())
            .ForMember(o => o.OwnerId, o => o.Ignore());


            Mapper.AssertConfigurationIsValid();
        }
    }
}
