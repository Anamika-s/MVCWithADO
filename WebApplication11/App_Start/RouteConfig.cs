using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication11
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
               name: "StudentRoute1",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Student", action = "StudentList1", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "StudentRoute",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
