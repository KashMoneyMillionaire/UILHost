using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

namespace UILHost.Web
{
    public static class NinjectConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                // Set Web API Resolver (using WebApiContrib.Ioc.Ninject)
                GlobalConfiguration.Configuration.DependencyResolver = new Ninject.WebApi.DependencyResolver.NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load(new Infrastructure.IoC.RepositoryModule());

            kernel.Load(new Infrastructure.IoC.ServiceModule());
            //kernel.Load(new HttpEvironmentModule());

            Infrastructure.IoC.DependencyResolver.SetGetKernelDelegate(() => bootstrapper.Kernel);
        }

        private static string GetCurrentSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        private static string GetRequestIpAddress()
        {
            if (HttpContext.Current != null
                && HttpContext.Current.Request != null)
                return HttpContext.Current.Request.UserHostAddress;
            return "UNKNOWN";
        }

        //private static string GetCurrentUserName()
        //{
        //    return Infrastructure.IoC.DependencyResolver.GetDependency<IAuthenticationService>().GetCurrentUserUsername();
        //}
    }
}