namespace NameSorter.Tests;

public class NameSorterServiceTests
{
    [Fact]
    public void Run_SortsByLastNameThenGivenNames()
    {
        var source = new MemoryNameSource("Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder",
            "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner",
            "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter");

        var destination = new ConsoleDestination();

        new NameSorterService(source, destination).Run();

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
}
