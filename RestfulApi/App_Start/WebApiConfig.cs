using System.Web.Http;

namespace RestfulApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            config.Routes.MapHttpRoute(
                name: "RouteApi",
                routeTemplate: "api",
                defaults: new {controller = "API", action = "get"}
                );
        }
    }
}
