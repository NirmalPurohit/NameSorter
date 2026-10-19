namespace NameSorter.IO;

/// <summary>
/// An interface to support different input sources for sorting.
/// </summary>
public interface INameSource
{
    IEnumerable<string> ReadLines();
}