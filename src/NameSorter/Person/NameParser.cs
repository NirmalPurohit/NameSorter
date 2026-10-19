using NameSorter.ExceptionHandling;

namespace NameSorter.Person;

/// <summary>
/// Parses whitespace-separated names where the final word is the last name
/// and everything before it is a given name.
/// </summary>
public class NameParser
{
    public PersonName Parse(string line)
    {
        var words = line.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);

        if (words.Length < 2)
        {
            throw new InvalidNameException(
                $"\"{line}\" must contain at least one given name and a last name.");
        }

        return new PersonName(givenNames: words[..^1], lastName: words[^1]);
    }
}