using NameSorter.ExceptionHandling;

namespace NameSorter.Person;

/// <summary>
/// A model class representing the person's name. This also incorprates the validation requirements.
/// </summary>
public class PersonName
{
    public const int MinGivenNames = 1;
    public const int MaxGivenNames = 3;

    public PersonName(IEnumerable<string> givenNames, string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new InvalidNameException("The person's name is empty or not provided.");
        }
        var given = givenNames.ToList();
        if (given.Count is < MinGivenNames or > MaxGivenNames)
        {
            var fullName = string.Join(' ', given.Append(lastName));
            throw new InvalidNameException(
                $"A name needs {MinGivenNames} to {MaxGivenNames} given names, " +
                $"but \"{fullName}\" has {given.Count}.");
        }

        GivenNames = given;
        LastName = lastName;
    }

    public IReadOnlyList<string> GivenNames { get; }

    public string LastName { get; }

    /// <summary>The name as it should be displayed, e.g. "Adonis Julius Archer".</summary>
    public override string ToString() => string.Join(' ', GivenNames.Append(LastName));
}
