using Autofac;
using Shared.Bootstrap;
using System.Reflection;

namespace ProductManagement.Bootstrap
{
    public static class RegisterProductManagementModule
    {
        public static void AddModule(this ContainerBuilder builder, 
            string connectionString, 
            string readonlyConnectionString,
            Assembly mappingAssembly)
        {
            builder.AddFramework(connectionString, readonlyConnectionString, mappingAssembly);
            builder.RegisterModule(new ProductManagementModule());
        }
    }
}