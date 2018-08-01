using Advertisement.Interfaces;
using Advertisement.Repositories.InMemory;
using Autofac;

namespace Advertisement.Tests.Integration.IoC
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CustomerRepository>()
                .As<ICustomerRepository>();

            builder
                .RegisterType<ProductRepository>()
                .As<IProductRepository>();
        }
    }
}