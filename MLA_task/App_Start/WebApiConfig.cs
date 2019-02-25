using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MLA_task.ExceptionFilters;

namespace MLA_task
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.Filters.Add(new DemoExceptionFilterAttribute());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
