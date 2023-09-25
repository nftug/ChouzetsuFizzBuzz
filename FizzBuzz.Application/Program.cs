using FizzBuzz.Application.Services;
using FizzBuzz.Domain.Specs;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider =
    new ServiceCollection()
        .AddFizzBuzz(
            new CyclicNumberRule(3, "Fizz"),
            new CyclicNumberRule(5, "Buzz"),
            new PassThroughRule()
        )
        .BuildServiceProvider();

var printer = serviceProvider.GetRequiredService<FizzBuzzSequencePrinter>();
printer.PrintRange(1, 100);