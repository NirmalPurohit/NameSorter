using NameSorter.IO;

namespace NameSorter;

public class NameSorterService(
    INameSource nameSource,
    INameDestination nameDestination
)
{
    public void Run()
    {
        var sortedNames = nameSource.ReadLines()
            .Where(name => !string.IsNullOrWhiteSpace(name))
            
            // Spliting the name into a list
            .Select(name => name.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            
            // First we sort by the last name
            .OrderBy(names => names[^1], StringComparer.OrdinalIgnoreCase)
            
            // If the last name is same, we sort by the given name(s)
            .ThenBy(names => string.Join(' ', names[..^1]), StringComparer.OrdinalIgnoreCase)
            .Select(names => string.Join(' ', names));
        

            nameDestination.Write(sortedNames.ToList());
    }
}