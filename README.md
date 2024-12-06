# Spectre.Console Dependency Injection

This repo is attempting to use Microsoft.Extensions.Hosting and Microsoft.Extensions.DependencyInjection with Spectre.Console.

The `IExampleService` doesn't resolve to the same instance despite being registered as a singleton.

```bash
dotnet run --project SpectreDI example
```
