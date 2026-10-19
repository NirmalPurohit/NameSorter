namespace NameSorter.IO;

public interface INameSource
{
    IEnumerable<string> ReadLines();
}