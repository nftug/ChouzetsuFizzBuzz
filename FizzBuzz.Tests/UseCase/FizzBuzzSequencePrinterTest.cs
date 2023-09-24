using FizzBuzz.Application.Services;
using FizzBuzz.Core;

namespace FizzBuzz.Tests.UseCase;

public class FizzBuzzSequencePrinterTest
{
    [Fact]
    public void TestPrintNone()
    {
        // Arrange
        var converterMock = new Mock<INumberConverter>();
        var outputMock = new Mock<IOutput>();

        // Act
        var printer = new FizzBuzzSequencePrinter(converterMock.Object, outputMock.Object);
        printer.PrintRange(0, -1);

        // Assert
        converterMock.VerifyNoOtherCalls();
        outputMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void TestPrint1To3()
    {
        // Arrange
        var converterMock = new Mock<INumberConverter>();
        var outputMock = new Mock<IOutput>();
        converterMock
            .SetupSequence(x => x.Convert(It.IsInRange(1, 3, Moq.Range.Inclusive)))
            .Returns("1")
            .Returns("2")
            .Returns("Fizz");

        // Act
        var printer = new FizzBuzzSequencePrinter(converterMock.Object, outputMock.Object);
        printer.PrintRange(1, 3);

        // Assert
        outputMock.Verify(x => x.Write("1 1\n"), Times.Once);
        outputMock.Verify(x => x.Write("2 2\n"), Times.Once);
        outputMock.Verify(x => x.Write("3 Fizz\n"), Times.Once);
    }
}
