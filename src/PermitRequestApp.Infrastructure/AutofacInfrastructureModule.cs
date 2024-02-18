using System.Reflection;
using Ardalis.SharedKernel;
using Autofac;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using PermitRequestApp.Core.Interfaces;
using PermitRequestApp.Core.Models.LeaveRequest;
using PermitRequestApp.Infrastructure.Data;
using PermitRequestApp.Infrastructure.Data.Queries;
using PermitRequestApp.Infrastructure.Email;
using PermitRequestApp.UseCases.LeaveRequests.Create;
using PermitRequestApp.UseCases.LeaveRequests.List;
using PermitRequestApp.UseCases.LeaveRequests.Mappings;
using Module = Autofac.Module;

namespace PermitRequestApp.Infrastructure;

/// <summary>
/// An Autofac module responsible for wiring up services defined in Infrastructure.
/// Mainly responsible for setting up EF and MediatR, as well as other one-off services.
/// </summary>
public class AutofacInfrastructureModule : Module
{
  private readonly bool _isDevelopment = false;
  private readonly List<Assembly> _assemblies = new List<Assembly>();

  public AutofacInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
  {
    _isDevelopment = isDevelopment;
    AddToAssembliesIfNotNull(callingAssembly);
  }

  private void AddToAssembliesIfNotNull(Assembly? assembly)
  {
    if (assembly != null)
    {
      _assemblies.Add(assembly);
    }
  }

  private void LoadAssemblies()
  {
    // TODO: Replace these types with any type in the appropriate assembly/project
    var coreAssembly = Assembly.GetAssembly(typeof(LeaveRequest));
    var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));
    var useCasesAssembly = Assembly.GetAssembly(typeof(CreateLeaveRequestCommand));

    AddToAssembliesIfNotNull(coreAssembly);
    AddToAssembliesIfNotNull(infrastructureAssembly);
    AddToAssembliesIfNotNull(useCasesAssembly);
  }

  protected override void Load(ContainerBuilder builder)
  {
    LoadAssemblies();
    if (_isDevelopment)
    {
      RegisterDevelopmentOnlyDependencies(builder);
    }
    else
    {
      RegisterProductionOnlyDependencies(builder);
    }
    RegisterEF(builder);
    RegisterQueries(builder);
    RegisterMediatR(builder);
    registerAutoMapper(builder);

    builder.RegisterType<ListLeaveRequestQueryService>()
      .As<IListLeaveRequestQueryService>().InstancePerLifetimeScope();
  }
  private void registerAutoMapper(ContainerBuilder builder)
  {
    builder.RegisterAssemblyTypes(typeof(LeaveRequestMappingProfiles).Assembly)
            .Where(t => t.IsAssignableTo<IMapper>())
            .AsImplementedInterfaces()
            .SingleInstance();

    //builder.Register(context => new MapperConfiguration(cfg =>
    //{
    //  cfg.CreateMap<LeaveRequest, CreateLeaveRequestCommand>().ReverseMap();
    //  cfg.CreateMap<LeaveRequest, LeaveRequestDTO>().ReverseMap();
    //})).AsSelf().SingleInstance();

    //builder.Register(c =>
    //{
    //  //This resolves a new context that can be used later.
    //  var context = c.Resolve<IComponentContext>();
    //  var config = context.Resolve<MapperConfiguration>();
    //  return config.CreateMapper(context.Resolve);
    //})
    //.As<IMapper>()
    //.InstancePerLifetimeScope();
  }

  private void RegisterEF(ContainerBuilder builder)
  {
    builder.RegisterGeneric(typeof(EfRepository<>))
      .As(typeof(IRepository<>))
      .As(typeof(IReadRepository<>))
      .InstancePerLifetimeScope();
  }

  private void RegisterQueries(ContainerBuilder builder)
  {
    
  }

  private void RegisterMediatR(ContainerBuilder builder)
  {
    builder
      .RegisterType<Mediator>()
      .As<IMediator>()
      .InstancePerLifetimeScope();

    builder
      .RegisterGeneric(typeof(LoggingBehavior<,>))
      .As(typeof(IPipelineBehavior<,>))
      .InstancePerLifetimeScope();

    builder
      .RegisterType<MediatRDomainEventDispatcher>()
      .As<IDomainEventDispatcher>()
      .InstancePerLifetimeScope();

    var mediatrOpenTypes = new[]
    {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

    foreach (var mediatrOpenType in mediatrOpenTypes)
    {
      builder
        .RegisterAssemblyTypes(_assemblies.ToArray())
        .AsClosedTypesOf(mediatrOpenType)
        .AsImplementedInterfaces();
    }
  }

  private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
  {
    // NOTE: Add any development only services here
    builder.RegisterType<FakeEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();

    //builder.RegisterType<FakeListContributorsQueryService>()
    //  .As<IListContributorsQueryService>()
    //  .InstancePerLifetimeScope();
  }

  private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
  {
    // NOTE: Add any production only (real) services here
    builder.RegisterType<SmtpEmailSender>().As<IEmailSender>()
      .InstancePerLifetimeScope();
  }
}
