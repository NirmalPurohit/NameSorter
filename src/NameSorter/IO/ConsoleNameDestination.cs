using NameSorter.Person;

namespace NameSorter.IO;

/// <summary>
/// A concrete class to display the names on console.
/// </summary>
/// <param name="writer"></param>
public class ConsoleNameDestination(TextWriter writer) : INameDestination
{
    public void Write(in IList<PersonName> names)
    {
        foreach (var name in names)
        {
            writer.WriteLine(name.ToString());
        }
    }
}