using FizzBuzz.Core.Specs;

namespace FizzBuzz.Core.Tests.Specs;

public class CyclicNumberRuleTest
{
    [Fact]
    public void TestApply()
    {
        var rule = new CyclicNumberRule(0, "Buzz");

        rule.Apply("", 0).Should().Be("Buzz");
        rule.Apply("Fizz", 0).Should().Be("FizzBuzz");
    }

    [Fact]
    public void TestMatch()
    {
        var rule = new CyclicNumberRule(3, "");

        rule.Match("", 1).Should().BeFalse();
        rule.Match("", 3).Should().BeTrue();
        rule.Match("", 6).Should().BeTrue();
    }
}