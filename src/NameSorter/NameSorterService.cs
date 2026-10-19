namespace NameSorter;

public class NameSorterService
{
    public void Run(string filePath)
    {
        var sortedNames = File.ReadLines(filePath)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            
            // Spliting the name into a list
            .Select(name => name.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            
            // First we sort by the last name
            .OrderBy(names => names[^1], StringComparer.OrdinalIgnoreCase)
            
            // If the last name is same, we sort by the given name(s)
            .ThenBy(names => string.Join(' ', names[..^1]), StringComparer.OrdinalIgnoreCase)
            .Select(names => string.Join(' ', names));
        
        foreach(var name in sortedNames)
        {
            Console.WriteLine(name);
        }
    }
}