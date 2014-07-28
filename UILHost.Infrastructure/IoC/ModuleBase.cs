using Ninject.Modules;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Web;
using Ninject.Web.Common;
using Ninject.Activation;

namespace UILHost.Infrastructure.IoC
{
    public class ModuleBase : NinjectModule
    {
        protected bool IsRequestScopeAvailable
        {
            get { return HttpContext.Current != null; }
        }

        protected void BindForTransientScope<TFrom, TTo>(
            Dictionary<string, object> constructorArguments = null, 
            Action<IBindingNamedWithOrOnSyntax<TTo>> bindingInterceptAction = null) where TTo : TFrom
        {
            var binding = this.ApplyConstructorArguments(Bind<TFrom>().To<TTo>().When(ctx => this.IsRequestScopeAvailable).InRequestScope(), constructorArguments);
            if (bindingInterceptAction != null) bindingInterceptAction(binding);

            binding = this.ApplyConstructorArguments(Bind<TFrom>().To<TTo>().When(ctx => !this.IsRequestScopeAvailable).InThreadScope(), constructorArguments);
            if (bindingInterceptAction != null) bindingInterceptAction(binding);
        }

        protected void BindToSelfForTransientScope<TDep>(
            Dictionary<string, object> constructorArguments = null,
            Action<IBindingNamedWithOrOnSyntax<TDep>> bindingInterceptAction = null)
        {
            var binding = this.ApplyConstructorArguments(Bind<TDep>().ToSelf().When(ctx => this.IsRequestScopeAvailable).InRequestScope(), constructorArguments);
            if (bindingInterceptAction != null) bindingInterceptAction(binding);

            binding = this.ApplyConstructorArguments(Bind<TDep>().ToSelf().When(ctx => !this.IsRequestScopeAvailable).InThreadScope(), constructorArguments);
            if (bindingInterceptAction != null) bindingInterceptAction(binding);
        }

        protected void BindToMethodForTransientScope<TDep>(Func<IContext, TDep> method, Dictionary<string, object> constructorArguments = null)
        {
            this.ApplyConstructorArguments(Bind<TDep>().ToMethod(method).When(ctx => this.IsRequestScopeAvailable).InRequestScope(), constructorArguments);
            this.ApplyConstructorArguments(Bind<TDep>().ToMethod(method).When(ctx => !this.IsRequestScopeAvailable).InThreadScope(), constructorArguments);
        }

        private IBindingNamedWithOrOnSyntax<TTo> ApplyConstructorArguments<TTo>(IBindingNamedWithOrOnSyntax<TTo> bindingSyntax, 
            Dictionary<string, object> constructorArguments)
        {
            if(constructorArguments != null)
            {
                foreach (var item in constructorArguments)
                    bindingSyntax.WithConstructorArgument(item.Key, item.Value);
            }

            return bindingSyntax;
        }

        public override void Load()
        {
            // do nothing
        }

    }
}
