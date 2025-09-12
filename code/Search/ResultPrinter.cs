using Search.CsvInput;
using Search.Service;

namespace search;

public class ResultPrinter(IFilterService filterService)
{
    // public void PrintResults( IDatatReader datatReader, string name)
    public void PrintResults(string name)
    {
        var filteredCsvEntries = filterService.FilterByName(name);
        foreach (var entry in filteredCsvEntries)
        {
            Console.WriteLine($"{entry.Name} @ ({entry.Latitude}, {entry.Longitude})");
        }
    }
}