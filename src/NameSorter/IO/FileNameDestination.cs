using NameSorter.Person;

namespace NameSorter.IO;

/// <summary>
/// A concrete class to stream the names to a file.
/// </summary>
/// <param name="filePath"></param>
public class FileNameDestination(string filePath) : INameDestination
{
    public void Write(in IList<PersonName> names) =>
        File.WriteAllLines(filePath, names.Select(name => name.ToString()));
}