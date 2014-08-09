using Ninject;
using System;

namespace UILHost.Infrastructure.IoC
{
    public static class DependencyResolver
    {
        private static Func<IKernel> _getKernelDelegate = null;

        public static bool HasKernel { get { return _getKernelDelegate != null; } }

        public static void SetGetKernelDelegate(Func<IKernel> getKernelDelegate)
        {
            _getKernelDelegate = getKernelDelegate;
        }

        public static TDependency GetDependency<TDependency>()
        {
            if(_getKernelDelegate == null)
                throw new InvalidOperationException("The getKernelDelegate is null.");

            var kernel = _getKernelDelegate();

            if(kernel == null)
                throw new InvalidOperationException("The getKernelDelegate returns a null kernel");

            return kernel.Get<TDependency>();
        }
    }
}
