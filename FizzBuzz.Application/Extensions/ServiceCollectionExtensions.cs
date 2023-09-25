using FizzBuzz.Application.Services;
using FizzBuzz.Domain.Core;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFizzBuzz(
        this IServiceCollection services,
        params IReplaceRule[] rules
    )
    {
        services = services
            .AddSingleton<INumberConverter, NumberConverter>()
            .AddSingleton<IOutput, ConsoleOutput>()
            .AddSingleton<FizzBuzzSequencePrinter>();

        foreach (var rule in rules)
        {
            services.AddSingleton(_ => rule);
        }

        return services;
    }

}
