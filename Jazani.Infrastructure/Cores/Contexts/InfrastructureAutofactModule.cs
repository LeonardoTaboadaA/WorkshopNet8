using System.Reflection;
using Autofac;

namespace Jazani.Infrastructure.Cores.Contexts;

public class InfrastructureAutofactModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
        
    }
}