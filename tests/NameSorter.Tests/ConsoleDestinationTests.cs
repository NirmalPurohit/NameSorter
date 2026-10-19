using NameSorter.IO;
using NameSorter.Person;

namespace NameSorter.Tests;

/// <summary>
/// Tests for validating the output destination behaviour.
/// </summary>
public class ConsoleDestinationTests
{
    [Fact]
    public void Write_PutsOneNamePerLine()
    {
        var writer = new StringWriter();
        var names = new List<PersonName> { new(["Marin"], "Alvarez"), new(["Janet"], "Parsons") };

        new ConsoleNameDestination(writer).Write(names);

        Assert.Equal(
            $"Marin Alvarez{Environment.NewLine}Janet Parsons{Environment.NewLine}",
            writer.ToString());
    }
}