
namespace FizzBuzz.Core;

public class NumberConverter
{
    private readonly IReplaceRule[] _rules;

    public NumberConverter(IReplaceRule[] rules)
    {
        _rules = rules;
    }

    public string Convert(int n) =>
        _rules
            .Aggregate(
                string.Empty,
                (carry, rule) => rule.Match(carry, n) ? rule.Apply(carry, n) : carry
            );
}
