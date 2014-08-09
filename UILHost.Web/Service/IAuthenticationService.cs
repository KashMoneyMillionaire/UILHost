using UILHost.Infrastructure.Domain;

namespace UILHost.Web.Services
{
    public interface IAuthenticationService
    {
        string GetCurrentUserFirstName();
        string GetCurrentUserUsername();
        long GetCurrentUserId();
        void SignIn(Teacher teacher, bool persist);
        void SignOut();
    }
}