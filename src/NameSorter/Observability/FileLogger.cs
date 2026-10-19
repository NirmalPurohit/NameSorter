namespace NameSorter.Observability;

public class FileLogger : ILogger
{
    private const string logFile = "app.log";

    public void log(string message)
    {
        File.AppendAllText(logFile, Environment.NewLine + DateTime.UtcNow + message);
    }
}