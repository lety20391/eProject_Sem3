using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ArtInstitute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "Home/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "User/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Staff",
                url: "Staff/{action}/{id}",
                defaults: new { controller = "Staff", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Student",
                url: "Student/{action}/{id}",
                defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Exhibition",
                url: "Exhibition/{action}/{id}",
                defaults: new { controller = "Exhibition", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Competition",
                url: "Competition/{action}/{id}",
                defaults: new { controller = "Competition", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Award",
                url: "Award/{action}/{id}",
                defaults: new { controller = "Award", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
