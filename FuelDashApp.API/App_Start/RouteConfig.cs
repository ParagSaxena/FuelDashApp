using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace FuelDashApp.API.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
    public static class SwaggerExtensions
    {
    }
}