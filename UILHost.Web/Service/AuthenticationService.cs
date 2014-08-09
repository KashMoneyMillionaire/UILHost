using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.Services.Interface;
using UILHost.Web.Services;
using Microsoft.Owin.Security;

namespace UILHost.Web.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITeacherService _teacherSvc;

        private readonly IAuthenticationManager _authManager = null;

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current != null
                    ? HttpContext.Current.GetOwinContext().Authentication
                    : _authManager;
            }
        }
        
        public AuthenticationService(
            ITeacherService teacherSvc)
        {
            _teacherSvc = teacherSvc;
        }

        public string GetCurrentUserUsername()
        {
            var userUsernameClaim = AuthenticationManager.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.Name);

            if (userUsernameClaim == null)
                return "";

            return userUsernameClaim.Value;
        }

        public long GetCurrentUserId()
        {
            var claim = AuthenticationManager.User.Claims
                .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (claim != null)
                return long.Parse(claim.Value);
            return -1;
        }

        public string GetCurrentUserFirstName()
        {
            var userProfile = _teacherSvc.Find(GetCurrentUserId());
            if (userProfile != null)
                return userProfile.FirstName;
            return string.Empty;
        }

        public void SignIn(Teacher teacher, bool persist)
        {
            SignOut();

            var identity =
                new ClaimsIdentity(
                new[] 
                            { 
                                new Claim(ClaimTypes.Name, teacher.Email),
                                new Claim(ClaimTypes.NameIdentifier, teacher.Id.ToString(CultureInfo.InvariantCulture))
                            },
                DefaultAuthenticationTypes.ApplicationCookie,
                ClaimTypes.Name,
                ClaimTypes.Role);

            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = persist }, identity);
        }

        public void SignOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}