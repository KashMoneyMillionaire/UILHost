using UILHost.Infrastructure;
using UILHost.Infrastructure.IoC;
using UILHost.Infrastructure.Services;
using UILHost.Infrastructure.Services.Interface;

namespace UILHost.Infrastructure.IoC
{
    public class ServiceModule : ModuleBase
    {
        public override void Load()
        {
            //base.BindForTransientScope<IUserProfileService, UserProfileService>();
            base.BindForTransientScope<IStateService, StateService>();

            var portalRootUrl = AppConfigFacade.WebPortalRootUrl.Trim().TrimEnd('/');

            
        }


    }
}   