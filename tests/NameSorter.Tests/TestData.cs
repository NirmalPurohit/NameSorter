using NameSorter.IO;

namespace NameSorter.Tests;

internal sealed class MemoryNameSource(params string[] names) : INameSource
{
    public IEnumerable<string> ReadLines() => names;
}

internal sealed class ConsoleDestination : INameDestination
{
    public List<string> Lines {get;} = [];

    public void Write(in IList<string> names) =>
        Lines.AddRange(names.Select(name => name));

}