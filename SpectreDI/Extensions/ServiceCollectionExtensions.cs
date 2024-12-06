using Microsoft.Extensions.DependencyInjection;

using Spectre.Console.Cli;

using SpectreDI.DependencyInjection;

namespace SpectreDI.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddUserCancellation(this IServiceCollection services)
  {
    var cts = new CancellationTokenSource();
    Console.CancelKeyPress += (sender, eventArgs) =>
    {
      eventArgs.Cancel = true;
      cts.Cancel();
    };

    services.AddSingleton(cts);

    return services;
  }

  public static IServiceCollection AddCommandLine(this IServiceCollection services, Action<IConfigurator> configurator)
  {
    var app = new CommandApp(new TypeRegistrar(services));

    app.Configure(configurator);
    services.AddSingleton<ICommandApp>(app);

    return services;
  }

  public static IServiceCollection AddCommandLine<TDefaultCommand>(this IServiceCollection services, Action<IConfigurator> configurator)
    where TDefaultCommand : class, ICommand
  {
    var app = new CommandApp<TDefaultCommand>(new TypeRegistrar(services));

    app.Configure(configurator);
    services.AddSingleton<ICommandApp>(app);

    return services;
  }
}
