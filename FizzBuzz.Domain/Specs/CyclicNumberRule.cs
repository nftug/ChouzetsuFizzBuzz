using FizzBuzz.Domain.Core;

namespace FizzBuzz.Domain.Specs;

public class CyclicNumberRule : IReplaceRule
{
    private readonly int _base;
    private readonly string _replacement;

    public CyclicNumberRule(int @base, string replacement)
    {
        _base = @base;
        _replacement = replacement;
    }

    public string Apply(string carry, int n) => carry + _replacement;

    public bool Match(string carry, int n) => n % _base == 0;
}
