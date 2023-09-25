namespace FizzBuzz.Domain.Core;

public class NumberConverter : INumberConverter
{
    private readonly IReplaceRule[] _rules;

    public NumberConverter(IEnumerable<IReplaceRule> rules)
    {
        _rules = rules.ToArray();
    }

    public string Convert(int n) =>
        _rules
            .Aggregate(
                string.Empty,
                (carry, rule) => rule.Match(carry, n) ? rule.Apply(carry, n) : carry
            );
}
