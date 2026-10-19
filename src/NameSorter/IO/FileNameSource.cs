namespace NameSorter.IO;

/// <summary>
/// A concrete class to provide a file stream as in input to read the names.
/// </summary>
/// <param name="filePath"></param>
public class FileNameSource(string filePath): INameSource
{
    public IEnumerable<string> ReadLines() => File.ReadAllLines(filePath);
}