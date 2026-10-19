using NameSorter.Observability;
using NameSorter.Person;

namespace NameSorter.IO;

/// <summary>
/// A concrete class to stream the names to a file.
/// </summary>
/// <param name="filePath"></param>
public class FileNameDestination(string filePath, ILogger? logger = null) : INameDestination
{
    public void Write(in IList<PersonName> names)
    {
        try
        {
            logger?.log("Writing to file.");
            File.WriteAllLines(filePath, names.Select(name => name.ToString()));
            logger?.log("Completed writing to file.");
        }
        catch (Exception ex)
        {
            logger?.log("Error while writing to the file!" + ex.Message);
        }
    }
}