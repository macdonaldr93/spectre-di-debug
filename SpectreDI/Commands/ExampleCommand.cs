using Spectre.Console;
using Spectre.Console.Cli;

using SpectreDI.Services;

namespace SpectreDI.Commands;

// The singleton registered in the ServiceCollection is not being injected here.
// A new instance is being created.
public sealed class ExampleCommand(IExampleService service) : Command<ExampleCommand.Settings>
{
  private readonly IExampleService _service = service;

  public sealed class Settings : CommandSettings
  {
    [CommandOption("-o|--out")]
    public string OutputPath { get; init; } = Environment.CurrentDirectory;
  }

  public override int Execute(CommandContext ctx, Settings settings)
  {
    AnsiConsole.WriteLine($"ExampleCommand->IExampleService hash code: {_service.GetHashCode()}");

    return 0;
  }
}
