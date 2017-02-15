using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Vidly
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route with validations

            //routes.MapRoute("moviesByReleaseDate",
            //    "movies/released/{year}/{month}",
            //    new{ controller = "Movies",action= "ByReleaseDate"},
            //    new { year = @"2015|2016", month = @"\d{2}" }
            //    );


            //Built Routes by Attributes(Is the best way to use Routes)
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Movies",
                url: "{controller}/{action}",
                defaults: new { controller = "Movies", action = "Index", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Customer",
                url: "{controller}/{action}",
                defaults: new {controller = "Customers", action = "Index", id = UrlParameter.Optional}
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
