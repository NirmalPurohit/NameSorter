using NameSorter.Observability;

namespace NameSorter.IO;

/// <summary>
/// A concrete class to provide a file stream as in input to read the names.
/// </summary>
/// <param name="filePath"></param>
public class FileNameSource(string filePath, ILogger? logger = null): INameSource
{
    public IEnumerable<string> ReadLines()
    {
        try
        {
            logger?.log("Reading from file.");
            return File.ReadAllLines(filePath);
        } 
        catch (FileNotFoundException)
        {
            logger?.log("Source file not found");
            throw;
        }
    }
}