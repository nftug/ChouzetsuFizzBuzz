using FizzBuzz.Domain.Core;

namespace FizzBuzz.Tests.Core;

public class NumberConverterTest
{
    [Fact]
    public void TestConvertWithEmptyRules()
    {
        var fizzBuzz = new NumberConverter(Array.Empty<IReplaceRule>());
        fizzBuzz.Convert(1).Should().Be("");
    }

    [Fact]
    public void TestConvertWithSingleRule()
    {
        var fizzBuzz = new NumberConverter(new[]
        {
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "",
                matchResult: true,
                replacement: "Replaced"
            )
        });

        fizzBuzz.Convert(1).Should().Be("Replaced");
    }

    [Fact]
    public void TestConvertCompositionRuleResults()
    {
        var fizzBuzz = new NumberConverter(new[]
        {
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "",
                matchResult: true,
                replacement: "Fizz"
            ),
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "Fizz",
                matchResult: true,
                replacement: "FizzBuzz"
            )
        });

        fizzBuzz.Convert(1).Should().Be("FizzBuzz");
    }

    [Fact]
    public void TestConvertSkippingUnmatchedRules()
    {
        var fizzBuzz = new NumberConverter(new[]
        {
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "",
                matchResult: false,
                replacement: "Fizz"
            ),
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "",
                matchResult: false,
                replacement: "Buzz"
            ),
            CreateMockRule(
                expectedNumber: 1,
                expectedCarry: "",
                matchResult: true,
                replacement: "1"
            ),
        });

        fizzBuzz.Convert(1).Should().Be("1");
    }

    private IReplaceRule CreateMockRule(
        int expectedNumber,
        string expectedCarry,
        bool matchResult,
        string replacement
    )
    {
        var rule = new Mock<IReplaceRule>();
        rule
            .Setup(x => x.Apply(expectedCarry, expectedNumber))
            .Returns(replacement);
        rule
            .Setup(x => x.Match(expectedCarry, expectedNumber))
            .Returns(matchResult);
        return rule.Object;
    }
}