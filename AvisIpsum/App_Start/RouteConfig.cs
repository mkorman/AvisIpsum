using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvisIpsum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Display Paragraphs",
                url: "{paragraphs}",
                defaults: new { controller = "Home", action = "Index", paragraphs = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{paragraphs}",
                defaults: new { controller = "Home", action = "Index", paragraphs = UrlParameter.Optional }
            );
        }
    }
}