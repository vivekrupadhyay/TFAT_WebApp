using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TFATERPWebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Dynamic",
                "Dynamic/Master/{id}/{ViewName}/{ViewType}",
                new { controller = "Dynamic", action = "Master", id = UrlParameter.Optional, ViewName = UrlParameter.Optional, ViewType = UrlParameter.Optional }
            );
        }
    }
}