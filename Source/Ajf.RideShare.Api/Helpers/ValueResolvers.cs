using AutoMapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TripGallery.API.Helpers
{
    public class InjectImageBaseForPictureResolver : ValueResolver<Repository.Entities.Picture,string>
    {

        protected override string ResolveCore(Repository.Entities.Picture source)
        { 
            string fullUri =ConfigurationManager.AppSettings["UrlRideShareApi"]  + source.Uri;
            return fullUri;
        }
    }

    public class InjectImageBaseForTripResolver : ValueResolver<Repository.Entities.Trip, string>
    {

        protected override string ResolveCore(Repository.Entities.Trip source)
        {
            string fullUri = ConfigurationManager.AppSettings["UrlRideShareApi"] + source.MainPictureUri;
            return fullUri;
        }
    }


    public class RemoveImageBaseForTripResolver : ValueResolver<DTO.Trip, string>
    {

        protected override string ResolveCore(DTO.Trip source)
        {
            string partialUri = source.MainPictureUri;
            // find
            var tripGalleryApi = ConfigurationManager.AppSettings["UrlRideShareApi"];
            var indexOfUri = partialUri.IndexOf(tripGalleryApi);
            if (indexOfUri > -1)
            {
                partialUri = partialUri.Substring(tripGalleryApi.Length);
            }
           
            return partialUri;
        }
    }






}