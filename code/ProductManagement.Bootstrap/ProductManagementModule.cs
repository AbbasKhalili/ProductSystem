using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Product.CommandHandlers;
using ProductManagement.Core;
using ProductManagement.Domain.EventHandlers.ProductEventHandlers;
using ProductManagement.Domain.Products.DomainServices;
using ProductManagement.Interface.ReadModel;
using ProductManagement.Interface.WriteModel;
using ProductManagement.Persistance;
using ProductManagement.Persistance.Mappings;
using ProductManagement.Persistance.Repositories;
using Shared.Application;
using Shared.Core;
using Shared.Core.EventHandlers;
using Shared.Domain;
using Shared.EF;

namespace ProductManagement.Bootstrap
{
    public class ProductManagementModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ProductRepository).Assembly)
                .Where(a => typeof(IRepository).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<PrivacyRepository>().As<IPrivacyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(SecurityInterceptor));

            builder.RegisterAssemblyTypes(typeof(ProductFacadeService).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(SecurityInterceptor))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProductFacadeQuery).Assembly)
                .Where(a => typeof(IFacadeService).IsAssignableFrom(a))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(SecurityInterceptor))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(StockQuantityService).Assembly)
                .Where(a => typeof(IDomainService).IsAssignableFrom(a))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ProductCreatedEventHandler).Assembly)
                .AsClosedTypesOf(typeof(IEventHandler<>)).InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(typeof(ProductCreateCommandHandler).Assembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>)).InstancePerLifetimeScope();
        }
    }
}