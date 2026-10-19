/// Main file to execute the application.

using NameSorter;
using NameSorter.IO;
using NameSorter.Person;

if (args.Length != 1)
{
    Console.Error.WriteLine("Missing arguments! Usage: name-sorter <FILEPATH>");
    return 1;
}

const string outputFile = "sorted-names-list.txt";

new NameSorterService(
        new FileNameSource(args[0]), 
        new FileNameDestination(outputFile),
        new NameParser(),
        new NameComparer()
    ).Run();
return 0;