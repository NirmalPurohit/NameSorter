namespace NameSorter.Observability;

public class ConsoleLogger : ILogger
{
    public void log(string message)
    {
        Console.WriteLine(message);
    }
}