using NameSorter.IO;
using NameSorter.Person;

namespace NameSorter.Tests;

public sealed class FileDestinationTests : IDisposable
{
    private readonly string _path = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.txt");

    public void Dispose()
    {
        if (File.Exists(_path)) File.Delete(_path);
    }

    [Fact]
    public void Write_PutsOneNamePerLine()
    {
        var names = new List<PersonName> { new(["Marin"], "Alvarez"), new(["Janet"], "Parsons") };

        new FileNameDestination(_path).Write(names);

        Assert.Equal(["Marin Alvarez", "Janet Parsons"], File.ReadAllLines(_path));
    }

    [Fact]
    public void Write_OverwritesAnExistingFile()
    {
        File.WriteAllText(_path, "stale content");

        new FileNameDestination(_path).Write([new PersonName(["Marin"], "Alvarez")]);

        Assert.Equal(["Marin Alvarez"], File.ReadAllLines(_path));
    }
}