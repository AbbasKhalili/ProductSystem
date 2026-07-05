using Autofac;
using Shared.Core;

namespace Shared.Autofac
{
    public class ServiceLocator(ILifetimeScope lifetimeScope) : IServiceLocator
    {
        private readonly ILifetimeScope _lifetimeScope = lifetimeScope;

        public T GetInstance<T>() where T : class
        {
            return _lifetimeScope.Resolve<T>();
        }

        public object GetInstance(Type serviceType)
        {
            return _lifetimeScope.Resolve(serviceType);
        }
    }
}
