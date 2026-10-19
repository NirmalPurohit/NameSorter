namespace NameSorter.IO;

public interface INameDestination
{
    void Write(in IList<string> names);
}