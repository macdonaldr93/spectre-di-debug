using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Spectre.Console.Cli;

namespace SpectreDI.Extensions;

public static class HostExtensions
{
  public static async Task<int> RunAsync(this IHost host, string[] args)
  {
    var cts = host.Services.GetRequiredService<CancellationTokenSource>();
    var app = host.Services.GetRequiredService<ICommandApp>();

    await host.StartAsync(cts.Token);

    return app.Run(args);
  }
}
