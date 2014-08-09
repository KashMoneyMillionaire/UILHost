using System.Web.Mvc;
using System.Web.Routing;

namespace UILHost.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                result: MVC.Account.Login(),
                defaults: new { id = UrlParameter.Optional },
                namespaces: new[] { "UILHost.Web.Controllers" }
            );



        }
    }
}
