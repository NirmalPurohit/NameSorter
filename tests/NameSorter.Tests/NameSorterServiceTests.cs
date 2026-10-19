using NameSorter.Person;
using NameSorter.ExceptionHandling;

namespace NameSorter.Tests;

/// <summary>
/// Tests <see cref="NameSorterService"/> with edge cases and error prone input.
/// </summary>
public class NameSorterServiceTests
{

    private static NameSorterService CreateNameSorterService(MemoryNameSource source, MemoryDestination destination) =>
        new(source, destination, new NameParser(), new NameComparer(), null);

    [Fact]
    public void Run_SortsByLastNameThenGivenNames()
    {
        var source = new MemoryNameSource("Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder",
            "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner",
            "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter");

        var destination = new MemoryDestination();

        CreateNameSorterService(source, destination).Run();

        Assert.Equal(
            [
                "Marin Alvarez", "Adonis Julius Archer", "Beau Tristan Bentley",
                "Hunter Uriah Mathew Clarke", "Leo Gardner", "Vaughn Lewis",
                "London Lindsey", "Mikayla Lopez", "Janet Parsons",
                "Frankie Conner Ritter", "Shelby Nathan Yoder"
            ],
            destination.Lines
        );

    }

    [Fact]
    public void Run_SortsPeopleSharingALastNameByGivenNames()
    {
        var destination = new MemoryDestination();

        CreateNameSorterService(new MemoryNameSource("Zoe Smith", "Adam Smith", "Adam Zed Smith"), destination).Run();

        Assert.Equal(["Adam Smith", "Adam Zed Smith", "Zoe Smith"], destination.Lines);
    }

    [Fact]
    public void Run_SkipsBlankLines()
    {
        var destination = new MemoryDestination();

        CreateNameSorterService(new MemoryNameSource("Janet Parsons", "", "   ", "Marin Alvarez"), destination).Run();

        Assert.Equal(["Marin Alvarez", "Janet Parsons"], destination.Lines);
    }

    [Fact]
    public void Run_WithAnInvalidName_ThrowsAndWritesNothing()
    {
        var destination = new MemoryDestination();
        var service = CreateNameSorterService(new MemoryNameSource("Marin Alvarez", "Madonna"), destination);

        Assert.Throws<InvalidNameException>(service.Run);
        Assert.Empty(destination.Lines);
    }
}
