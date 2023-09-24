using FizzBuzz.Application.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider =
    new ServiceCollection()
        .AddFizzBuzz()
        .BuildServiceProvider();

var printer = serviceProvider.GetRequiredService<FizzBuzzSequencePrinter>();
printer.PrintRange(1, 100);