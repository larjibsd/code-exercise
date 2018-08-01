using System;
using System.Linq;
using System.Reflection;
using Advertisement.Domain;
using Advertisement.Domain.PricingRules;
using Autofac;
using Module = Autofac.Module;

namespace Advertisement.Tests.Integration.IoC
{
    public class PricingRulesModule : Module
    {
        private static string AssemblyName => "Advertisement.Domain";

        protected override void Load(ContainerBuilder builder)
        {
            var assembly = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SingleOrDefault(a => a.GetName().Name == AssemblyName);

            assembly = assembly ?? Assembly.Load(AssemblyName);

            builder
                .RegisterAssemblyTypes(assembly)
                .Where(t => typeof (ISpecialPricingRule).IsAssignableFrom(t))
                .As<ISpecialPricingRule>()
                .InstancePerLifetimeScope();
        }
    }
}