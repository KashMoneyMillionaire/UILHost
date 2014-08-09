using System.Web.Mvc;

namespace UILHost.Web.Controllers
{
    public partial class ErrorController : Controller
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult NotFound()
        {
            return View();
        }

        public virtual ActionResult AccessDenied()
        {
            return View();
        }
    }
}