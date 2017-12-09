﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using IdentityModel.Client;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using TripGallery.DTO;
using TripGallery.MVCClient.Helpers;
using TripGallery.MVCClient.Models;

namespace Ajf.RideShare.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Trips
        public async Task<ActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = this.User.Identity as ClaimsIdentity;
                foreach (var claim in identity.Claims)
	            {
                    Debug.WriteLine(claim.Type + " - " + claim.Value);
	            }               
            } 

            var httpClient = TripGalleryHttpClient.GetClient();

            var rspTrips = await httpClient.GetAsync("Api/Trips").ConfigureAwait(false);

            if (rspTrips.IsSuccessStatusCode)
            {
                var lstTripsAsString = await rspTrips.Content.ReadAsStringAsync().ConfigureAwait(false);          

                var vm = new TripsIndexViewModel();
                vm.Trips = JsonConvert.DeserializeObject<IList<Trip>>(lstTripsAsString).ToList();

                return View(vm);
            }
            else
            {
                return View("Error",
                         new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(rspTrips),
                        "Home", "Index"));              
            }        
        }

        // GET: Trips/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
         


        // GET: Trips/Create
        public ActionResult Create()
        {
            return View(new TripCreateViewModel(new TripForCreation()));
        }


        public async Task<ActionResult> Album(Guid tripId)
        {
            // get the access token.
            var token = (User.Identity as ClaimsIdentity).FindFirst("access_token").Value;

             UserInfoClient userInfoClient = new UserInfoClient(
                    new Uri(ConfigurationManager.AppSettings["IdentityServerApplicationUrl"] + "/connect/userinfo"),
                    token);

            var userInfoResponse = await userInfoClient.GetAsync();

            if (!userInfoResponse.IsError)
            {
                // create an object to return (dynamic Expando - anonymous 
                // types won't allow access to their properties from the view)
                dynamic addressInfo = new ExpandoObject();
                addressInfo.Address = userInfoResponse.Claims.First(c => c.Item1 == "address").Item2; 

                return View(addressInfo);
            }
            else
            {          
                var exception = new Exception("Problem getting your address.  Please contact your administrator.");
                return View("Error", new HandleErrorInfo(exception, "Home", "Album"));    
            }             
        }

        // POST: Trips/Create
        [HttpPost]
        public async Task<ActionResult> Create(TripCreateViewModel vm)
        {
            try
            {
 
                byte[] uploadedImage = new byte[vm.MainImage.InputStream.Length];
                vm.MainImage.InputStream.Read(uploadedImage, 0, uploadedImage.Length);

                vm.Trip.MainPictureBytes = uploadedImage;

                var httpClient = TripGalleryHttpClient.GetClient();

                var serializedTrip = JsonConvert.SerializeObject(vm.Trip);

                var response = await httpClient.PostAsync("api/trips", 
                    new StringContent(serializedTrip, System.Text.Encoding.Unicode, "application/json")).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");                        
                }
                else
                {
                    return View("Error", 
                            new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(response), 
                            "Home", "Create"));    
                } 
            }
            catch  (Exception ex)
            {  
                return View("Error", new HandleErrorInfo(ex, "Home", "Create"));    
            }
        }

     
        public async Task<ActionResult> SwitchPrivacyLevel(Guid id, bool isPublic)
        {
            
            // create a patchdocument to change the privacy level of this trip

            JsonPatchDocument<Trip> tripPatchDoc = new JsonPatchDocument<Trip>();
            tripPatchDoc.Replace(t => t.IsPublic, !isPublic);

            var httpClient = TripGalleryHttpClient.GetClient();

            var rspPatchTrip = await httpClient.PatchAsync("api/trips/" + id.ToString(),
                 new StringContent(JsonConvert.SerializeObject(tripPatchDoc), System.Text.Encoding.Unicode, "application/json"))
                 .ConfigureAwait(false);

            if (rspPatchTrip.IsSuccessStatusCode)
            {
                // the patch was succesful.  Reload.
                return RedirectToAction("Index", "Home");                          
            }
            else
            {
                return View("Error",
                         new HandleErrorInfo(ExceptionHelper.GetExceptionFromResponse(rspPatchTrip),
                        "Home", "SwitchPrivacyLevel"));              
            }
        } 
    }
}
