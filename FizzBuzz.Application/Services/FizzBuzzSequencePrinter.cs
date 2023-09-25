using FizzBuzz.Domain.Core;

namespace FizzBuzz.Application.Services;

public class FizzBuzzSequencePrinter
{
    private readonly INumberConverter _fizzBuzz;
    private readonly IOutput _output;

    public FizzBuzzSequencePrinter(INumberConverter fizzBuzz, IOutput output)
    {
        _fizzBuzz = fizzBuzz;
        _output = output;
    }

    public void PrintRange(int begin, int end)
    {
        for (int i = begin; i <= end; i++)
        {
            string text = _fizzBuzz.Convert(i);
            _output.Write($"{i} {text}\n");
        }
    }
}
