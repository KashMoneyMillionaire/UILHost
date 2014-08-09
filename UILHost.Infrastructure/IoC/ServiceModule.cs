using UILHost.Infrastructure.Services;
using UILHost.Infrastructure.Services.Interface;

namespace UILHost.Infrastructure.IoC
{
    public class ServiceModule : ModuleBase
    {
        public override void Load()
        {
            base.BindForTransientScope<IMeetService, MeetService>();
            base.BindForTransientScope<IStateService, StateService>();
            base.BindForTransientScope<ITeacherService, TeacherService>();

            var portalRootUrl = AppConfigFacade.WebPortalRootUrl.Trim().TrimEnd('/');

            
        }


    }
}   