namespace NameSorter.IO;

public class FileNameDestination(string filePath) : INameDestination
{
    public void Write(in IList<string> names) =>
        File.WriteAllLines(filePath, names);
}