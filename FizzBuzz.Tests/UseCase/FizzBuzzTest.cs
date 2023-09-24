using FizzBuzz.Core;
using FizzBuzz.Specs;

namespace FizzBuzz.Tests.UseCase;

public class FizzBuzzTest
{
    [Fact]
    public void TestFizzBuzz()
    {
        var fizzBuzz = new NumberConverter(
            new IReplaceRule[] {
                new CyclicNumberRule(3, "Fizz"),
                new CyclicNumberRule(5, "Buzz"),
                new PassThroughRule()
            });

        fizzBuzz.Convert(1).Should().Be("1");
        fizzBuzz.Convert(2).Should().Be("2");
        fizzBuzz.Convert(3).Should().Be("Fizz");
        fizzBuzz.Convert(5).Should().Be("Buzz");
        fizzBuzz.Convert(6).Should().Be("Fizz");
        fizzBuzz.Convert(10).Should().Be("Buzz");
        fizzBuzz.Convert(15).Should().Be("FizzBuzz");
        fizzBuzz.Convert(30).Should().Be("FizzBuzz");
    }
}
