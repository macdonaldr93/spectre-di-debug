using Spectre.Console;
using Spectre.Console.Cli;

namespace SpectreDI.DependencyInjection;

/// <summary>
/// Resolves services for Spectre.Console.Cli commands using Microsoft.Extensions.DependencyInjection.
/// </summary>
public sealed class TypeResolver(IServiceProvider provider) : ITypeResolver
{
  private readonly IServiceProvider _provider = provider;

  /// <summary>
  /// Resolves a service of the specified type.
  /// </summary>
  /// <param name="type">The type of the service to resolve.</param>
  /// <returns>The resolved service or <c>null</c> if not found.</returns>
  public object? Resolve(Type? type)
  {
    if (type is null)
    {
      return null;
    }

    try
    {
      return _provider.GetService(type);
    }
    catch (Exception ex)
    {
      // Spectre.Console.Cli intercepts exceptions thrown by `GetService`
      // and suppresses them, leading to misleading results where it assumes
      // the service is not found. To address this, we use a try/catch block
      // to log the exception details for debugging.
      AnsiConsole.WriteException(ex);
      throw;
    }
  }
}
