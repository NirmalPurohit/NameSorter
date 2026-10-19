namespace NameSorter.IO;

public class ConsoleDestination(TextWriter writer) : INameDestination
{
    public void Write(in IList<string> names)
    {
        foreach (var name in names)
        {
            writer.WriteLine(name);
        }
    }
}