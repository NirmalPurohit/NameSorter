/// Main file to execute the application.

using NameSorter;
using NameSorter.IO;
using NameSorter.Observability;
using NameSorter.Person;

if (args.Length != 1)
{
    Console.Error.WriteLine("Missing arguments! Usage: name-sorter <FILEPATH>");
    return 1;
}

const string outputFile = "sorted-names-list.txt";
ILogger logger = new FileLogger();

new NameSorterService(
        new FileNameSource(args[0], logger), 
        new FileNameDestination(outputFile, logger),
        new NameParser(),
        new NameComparer(),
        logger
    ).Run();
return 0;