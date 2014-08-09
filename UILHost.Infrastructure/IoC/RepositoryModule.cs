using System.Collections.Generic;
using UILHost.Infrastructure.Data;
using UILHost.Infrastructure.Domain;
using UILHost.Patterns.Repository.DataContext;
using UILHost.Patterns.Repository.EF6;
using UILHost.Patterns.Repository.Repositories;
using UILHost.Patterns.Repository.UnitOfWork;

namespace UILHost.Infrastructure.IoC
{
    public class RepositoryModule : ModuleBase
    {
        private readonly string _nameOrConnectionString;

        public RepositoryModule(
            string nameOrConnectionString = null)
        {
            _nameOrConnectionString = nameOrConnectionString;
        }

        public override void Load()
        {
            // UNIT OF WORK BINDINGS

            if (string.IsNullOrEmpty(_nameOrConnectionString))
                BindForTransientScope<IDataContextAsync, OperationalDataContext>(new Dictionary<string, object>()
                    {
                        { "nameOrConnectionString", Constants.DefaultConnectionStringName },
                        { "enableEfAutoDetectChanges", AppConfigFacade.EnableEfAutoDetectChanges }
                    });
            else
                BindForTransientScope<IDataContextAsync, OperationalDataContext>(new Dictionary<string, object>()
                    {
                        { "nameOrConnectionString", _nameOrConnectionString }
                    });

            BindForTransientScope<IUnitOfWorkAsync, UnitOfWork>();

            // REPOSITORY BINDINGS

            BindForTransientScope<IRepositoryAsync<Teacher>, Repository<Teacher>>();
            BindForTransientScope<IRepositoryAsync<Meet>, Repository<Meet>>();
            BindForTransientScope<IRepositoryAsync<State>, Repository<State>>();

        }

    }
}