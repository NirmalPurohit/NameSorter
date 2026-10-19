using NameSorter.IO;

namespace NameSorter.Tests;

public sealed class FileNameSourceTests
{
    private readonly string _path = "non_existing_file.txt";

    [Fact]
    public void Read_FileDoesNotExists()
    {
        Assert.Throws<FileNotFoundException>(() => new FileNameSource(_path).ReadLines());
    }
}