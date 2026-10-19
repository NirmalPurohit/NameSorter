/// Helper classes to create test data.

using NameSorter.IO;
using NameSorter.Person;

namespace NameSorter.Tests;

internal sealed class MemoryNameSource(params string[] names) : INameSource
{
    public IEnumerable<string> ReadLines() => names;
}

internal sealed class MemoryDestination : INameDestination
{
    public List<string> Lines {get;} = [];

    public void Write(in IList<PersonName> names) =>
        Lines.AddRange(names.Select(name => name.ToString()));

}