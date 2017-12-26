using System;
using System.Net.Http;

namespace Ajf.RideShare.Web.Helpers
{
    public static class ExceptionHelper
    {
        public static Exception GetExceptionFromResponse(HttpResponseMessage response)
        {
            // unauthorized => missing/bad auth
            // forbidden => you're authenticated, but you can't do this
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden
                || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                return  new Exception("You're not allowed to do that.");
            }

            var readAsStringAsync = response
                .Content
                .ReadAsStringAsync()
                .Result;

            return  new Exception("Something went wrong - please contact your administrator."+response.StatusCode +" "+readAsStringAsync);
        }
    }
}
