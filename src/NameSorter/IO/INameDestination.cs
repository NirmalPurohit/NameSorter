using NameSorter.Person;

namespace NameSorter.IO;

/// <summary>
/// An interface to support different output options for sorting.
/// </summary>
public interface INameDestination
{
    void Write(in IList<PersonName> names);
}