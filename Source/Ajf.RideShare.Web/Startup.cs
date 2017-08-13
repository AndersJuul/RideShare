using System;
using System.Collections.Generic;
using System.Linq;
using Ajf.RideShare.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Ajf.RideShare.Web.Startup))]

namespace Ajf.RideShare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ApplicationDbContext.UpdateDatabase();
        }
    }
}
