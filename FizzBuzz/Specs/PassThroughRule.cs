using FizzBuzz.Core;

namespace FizzBuzz.Specs;

public class PassThroughRule : IReplaceRule
{
    public string Apply(string carry, int n) => n.ToString();

    public bool Match(string carry, int n) => carry == string.Empty;
}
