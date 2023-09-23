using FizzBuzz.Specs;

namespace FizzBuzz.Core.Tests.Specs;

public class PassThroughTest
{
    [Fact]
    public void TestApply()
    {
        var rule = new PassThroughRule();

        rule.Apply("", 1).Should().Be("1");
        rule.Apply("", 2).Should().Be("2");
        rule.Apply("Fizz", 3).Should().Be("3");
    }

    [Fact]
    public void TestMatch()
    {
        var rule = new PassThroughRule();

        rule.Match("", 1).Should().BeTrue();
        rule.Match("", 2).Should().BeTrue();
        rule.Match("Fizz", 3).Should().BeFalse();
    }
}
