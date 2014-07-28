using System;
using System.Collections.Generic;
using UILHost.Infrastructure;
using UILHost.Infrastructure.ChangeDataCapture;
using UILHost.Infrastructure.Data;
using UILHost.Infrastructure.Data.Patterns;
using UILHost.Infrastructure.Domain;
using UILHost.Infrastructure.IoC;
using UILHost.Patterns.Repository.DataContext;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Repository.UnitOfWork;

namespace UILHost.Infrastructure.IoC
{
    public class RepositoryModule : ModuleBase
    {
        private readonly string _nameOrConnectionString;
        private readonly Func<string> _getCurrentUserNameFunc;
        private readonly Func<string> _getRequestIpAddressFunc;
        private readonly Func<string> _getCurrentSessionIdFunc;

        public RepositoryModule(
            string nameOrConnectionString = null, 
            Func<string> getCurrentUserNameFunc = null,
            Func<string> getRequestIpAddressFunc = null,
            Func<string> getCurrentSessionIdFunc = null)
        {
            _nameOrConnectionString = nameOrConnectionString;
            _getCurrentUserNameFunc = getCurrentUserNameFunc;
            _getRequestIpAddressFunc = getRequestIpAddressFunc;
            _getCurrentSessionIdFunc = getCurrentSessionIdFunc;
        }

        public override void Load()
        {
            // UNIT OF WORK BINDINGS

            if (string.IsNullOrEmpty(_nameOrConnectionString))
                base.BindForTransientScope<IDataContextAsync, OperationalDataContext>(new Dictionary<string, object>()
                    {
                        { "nameOrConnectionString", Constants.DefaultConnectionStringName },
                        { "enableEfAutoDetectChanges", AppConfigFacade.EnableEfAutoDetectChanges }
                    });
            else
                base.BindForTransientScope<IDataContextAsync, OperationalDataContext>(new Dictionary<string, object>()
                    {
                        { "nameOrConnectionString", _nameOrConnectionString }
                    });

            base.BindForTransientScope<IUnitOfWorkAsync, UnitOfWorkExt>();
            base.BindToSelfForTransientScope<ChangeDataCaptureStateManager>(new Dictionary<string, object>()
                    {
                        { "getCurrentUserNameFunc", _getCurrentUserNameFunc },
                        { "getRequestIpAddressFunc", _getRequestIpAddressFunc },
                        { "getCurrentSessionIdFunc", _getCurrentSessionIdFunc }
                    });

            // REPOSITORY BINDINGS

            base.BindForTransientScope<IRepositoryAsync<UserProfile>, RepositoryExt<UserProfile>>();

        }

    }
}