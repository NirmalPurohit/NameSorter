namespace NameSorter.Observability;

public class ErrorLogger : ILogger
{
    private const string errorFile = "app-error.log";

    public void log(string message)
    {
        File.AppendAllText(errorFile, Environment.NewLine + DateTime.UtcNow + message);
    }
}