using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // /trace.axd/1/2/3/4
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                // /home/contact/1
                // home -> value of the controller
                // contact -> value of the action
                // 1 -> value of the id

                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

                //Difference between this two is that the key is now going to be passed as a key,value
                // {action}?id=3  while id is passed as a path {action}/id
                //url: "{controller}/{action}/{key}",
                //defaults: new { controller = "Home", action = "Index", key = UrlParameter.Optional }
            );
        }
    }
}
