using NameSorter;
using NameSorter.IO;

if (args.Length != 1)
{
    Console.Error.WriteLine("Missing arguments! Usage: name-sorter <FILEPATH>");
    return 1;
}


new NameSorterService(new FileNameSource(args[0]), new ConsoleDestination(Console.Out)).Run();
return 0;