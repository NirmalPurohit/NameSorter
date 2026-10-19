using NameSorter;
using NameSorter.IO;

if (args.Length != 1)
{
    Console.Error.WriteLine("Missing arguments! Usage: name-sorter <FILEPATH>");
    return 1;
}

const string outputFile = "sorted-names-list.txt";

new NameSorterService(new FileNameSource(args[0]), new FileNameDestination(outputFile)).Run();
return 0;