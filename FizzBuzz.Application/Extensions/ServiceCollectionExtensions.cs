using FizzBuzz.Application.Services;
using FizzBuzz.Core;
using FizzBuzz.Specs;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFizzBuzz(this IServiceCollection services) =>
        services
            .AddSingleton<IReplaceRule>(_ => new CyclicNumberRule(3, "Fizz"))
            .AddSingleton<IReplaceRule>(_ => new CyclicNumberRule(5, "Buzz"))
            .AddSingleton<IReplaceRule>(_ => new PassThroughRule())
            .AddSingleton<INumberConverter, NumberConverter>()
            .AddSingleton<IOutput, ConsoleOutput>()
            .AddSingleton<FizzBuzzSequencePrinter>();
}
