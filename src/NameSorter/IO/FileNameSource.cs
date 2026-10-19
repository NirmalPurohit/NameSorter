namespace NameSorter.IO;

public sealed class FileNameSource(string filePath): INameSource
{
    public IEnumerable<string> ReadLines() => File.ReadAllLines(filePath);
}