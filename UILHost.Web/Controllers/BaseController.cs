using System.Web.Mvc;

namespace UILHost.Web.Controllers
{
    public abstract partial class BaseController : Controller
    {
        

        public virtual ActionResult RedirectToLocal(string returnUrl, bool addContext = false)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            
            return RedirectToAction(MVC.Home.ActionNames.Index, MVC.Home.Name);
        }

        public virtual string BuildLocalUrl(string controller, string action)
        {
            var returnUrl = string.Empty;

            if (string.IsNullOrEmpty(controller)) return returnUrl;

            returnUrl = string.Format("{0}/{1}", returnUrl, controller);

            if (!string.IsNullOrEmpty(action))
                returnUrl = string.Format("{0}/{1}", returnUrl, action);

            return returnUrl;
        }
    }
}