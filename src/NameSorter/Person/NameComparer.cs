using NameSorter.Observability;

namespace NameSorter.Person;

/// <summary>
/// Orders names by last name, then by each given name in turn.
/// If every shared given name matches, the name with fewer given names comes first.
/// Comparison ignores case.
/// </summary>
public class NameComparer : IComparer<PersonName>
{
    private static readonly StringComparer Text = StringComparer.InvariantCultureIgnoreCase;

    public int Compare(PersonName? x, PersonName? y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;

        var byLastName = Text.Compare(x.LastName, y.LastName);
        return byLastName != 0
            ? byLastName
            : CompareGivenNames(x.GivenNames, y.GivenNames);
    }

    private static int CompareGivenNames(IReadOnlyList<string> first, IReadOnlyList<string> second)
    {
        var sharedCount = Math.Min(first.Count, second.Count);

        for (var i = 0; i < sharedCount; i++)
        {
            var result = Text.Compare(first[i], second[i]);
            if (result != 0) return result;
        }

        return first.Count.CompareTo(second.Count);
    }
}