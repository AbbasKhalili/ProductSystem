using Autofac;
using Shared.Core;

namespace Shared.Autofac
{
    public static class ServiceRegistration
    {
        public static void RegisterServiceLocator(this ContainerBuilder builder)
        {
            builder.RegisterType<ServiceLocator>().As<IServiceLocator>()
                .InstancePerLifetimeScope();
        }
    }
}
