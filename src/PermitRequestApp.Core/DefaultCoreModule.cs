using Autofac;
using PermitRequestApp.Core.Interfaces;
using PermitRequestApp.Core.Services;

namespace PermitRequestApp.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<CreateLeaveRequestService>()
      .As<ICreateLeaveRequestService>().InstancePerLifetimeScope();
    
  }
}
