using Microsoft.Extensions.DependencyInjection;

using Spectre.Console.Cli;

namespace SpectreDI.DependencyInjection;

/// <summary>
/// Registers services for Spectre.Console.Cli commands using Microsoft.Extensions.DependencyInjection.
/// </summary>
public sealed class TypeRegistrar(IServiceCollection services) : ITypeRegistrar
{
  private readonly IServiceCollection _services = services;

  public void Register(Type service, Type implementation)
  {
    _services.AddSingleton(service, implementation);
  }

  public void RegisterInstance(Type service, object implementation)
  {
    _services.AddSingleton(service, implementation);
  }

  public void RegisterLazy(Type service, Func<object> factory)
  {
    _services.AddSingleton(service, _ => factory());
  }

  public ITypeResolver Build()
  {
    return new TypeResolver(_services.BuildServiceProvider());
  }
}
