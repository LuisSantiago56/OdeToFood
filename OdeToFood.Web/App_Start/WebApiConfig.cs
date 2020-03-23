using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdeToFood.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",

                // /api/restaurants/
                // to call the web api controller we need to start the url with "api"
                // then will be the controller
                // then the id or any other specific parameters

                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
