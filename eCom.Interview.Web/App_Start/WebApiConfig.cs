using System.Web.Http;

namespace eCom.Interview.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "EmailTemplate",
               routeTemplate: "api/emailtemplate/{id}",
               defaults: new { controller = "emailtemplate", id = RouteParameter.Optional }
            );
        }
    }
}
