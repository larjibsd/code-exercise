using Advertisement.Domain;
using Autofac;

namespace Advertisement.Tests.Integration.IoC
{
    public class IoCBootstrapper
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CheckOutProcessor>().AsSelf();

            builder.RegisterModule<PricingRulesModule>();

            builder.RegisterModule<RepositoryModule>();

            return builder.Build();
        }
    }
}
