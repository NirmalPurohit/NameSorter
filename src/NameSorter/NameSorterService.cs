using NameSorter.IO;
using NameSorter.Person;

namespace NameSorter;

/// <summary>
/// The main sorting service of the persons' names.
/// It uses <see cref="Linq"> to sort the names for the given requirement.
/// The requirment is to sort by the last name, if multiple people have same last name,
/// it will sort by the give name(s).
/// </summary>
/// <param name="nameSource">The input source from which the names will be read.</param>
/// <param name="nameDestination">The output path where the results should be written.</param>
/// <param name="nameParser">The parser to split and convert each name for sorting.</param>
/// <param name="nameComparer">The custom comparer for OrderBy to use.</param>
public class NameSorterService(
    INameSource nameSource,
    INameDestination nameDestination,
    NameParser nameParser,
    NameComparer nameComparer
)
{
    public void Run()
    {
        var sortedNames = nameSource.ReadLines()
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Select(nameParser.Parse)
            .OrderBy(name => name, nameComparer)
            .ToList();
        
        nameDestination.Write(sortedNames);
    }
}