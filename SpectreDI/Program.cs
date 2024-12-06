using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spectre.Console;
using Spectre.Console.Cli;

using SpectreDI.Commands;
using SpectreDI.Extensions;
using SpectreDI.Services;

var builder = Host.CreateDefaultBuilder();

builder.ConfigureServices((ctx, services) =>
{
  services.AddUserCancellation();

  // IExampleService is registered as a singleton here
  services.AddSingleton<IExampleService, ExampleService>();
  services.AddHostedService((sp) =>
  {
    var service = sp.GetRequiredService<IExampleService>();
    AnsiConsole.WriteLine($"HostedService->IExampleService hash code: {service.GetHashCode()}");
    return service;
  });

  services.AddCommandLine(config =>
  {
    config.UseAssemblyInformationalVersion();
    config.PropagateExceptions();
    config.AddCommand<ExampleCommand>("example");
  });
});

var host = builder.Build();
var exitCode = await host.RunAsync(args);

return exitCode;
