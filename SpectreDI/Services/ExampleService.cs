using Microsoft.Extensions.Hosting;

namespace SpectreDI.Services;

public interface IExampleService : IHostedService
{
  void DoSomething();
}

public class ExampleService : IExampleService
{
  public void DoSomething()
  {
    return;
  }

  public Task StartAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }

  public Task StopAsync(CancellationToken cancellationToken)
  {
    return Task.CompletedTask;
  }
}
