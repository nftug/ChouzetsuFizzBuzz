namespace FizzBuzz.Domain.Core;

public interface IReplaceRule
{
    string Apply(string carry, int n);

    bool Match(string carry, int n);
}
