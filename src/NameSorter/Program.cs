using NameSorter;

if (args.Length != 1)
{
    Console.Error.WriteLine("Missing arguments! Usage: name-sorter <FILEPATH>");
    return 1;
}

new NameSorterService().Run(args[0]);
return 0;