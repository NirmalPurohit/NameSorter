# Name Sorter

Sorts a list of names by last name, then by given names. Each name must have 1 to 3 given names.
Results are printed to the screen and written to `sorted-names-list.txt` in the working directory
(overwritten if it already exists).

## Run

Requires the .NET SDK (9.0, or change `TargetFramework` to match yours).

    dotnet run --project src/NameSorter -- ./unsorted-names-list.txt

## Test

    dotnet test

## Design

`NameSorterService` reads names from an `INameSource`, parses them with an `NameParser`,
sorts them with an `NameComparer<PersonName>`, and writes them to the chosen `INameDestination`.
`Program.cs` is the only place concrete classes are chosen.

- Sorting ignores case. Ties on every given name put the name with fewer given names first.
- Blank lines are skipped.
- An invalid line (no last name, or more than 3 given names) stops the run with an error and
  exit code 1, and nothing is written.

To add a new output format, implement `INameDestination` and replace it in `Program.cs`.
