using NameSorter.Observability;

namespace NameSorter.IO;

/// <summary>
/// A concrete class to provide a file stream as in input to read the names.
/// </summary>
/// <param name="filePath"></param>
public class FileNameSource(string filePath, ILogger? logger): INameSource
{
    public IEnumerable<string> ReadLines()
    {
        logger?.log("Reading from file.");
        return File.ReadAllLines(filePath);
    }
}