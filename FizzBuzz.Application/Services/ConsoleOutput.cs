namespace FizzBuzz.Application.Services;

public class ConsoleOutput : IOutput
{
    public void Write(string data) => Console.Write(data);
}
