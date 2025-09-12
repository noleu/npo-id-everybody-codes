using System.CommandLine;
using System.CommandLine.Parsing;
using Microsoft.Extensions.DependencyInjection;
using Search.CsvInput;
using Search.Service;

namespace  search;

public static class Program
{
    private static DirectoryInfo _baseDirectory;
    
    public static int Main(string[] args)
    {
        Option<String> nameOption = new("--name")
        {
            Description = "The name to search for.",
            Aliases = { "-n" },
            Required = true
        };
        RootCommand rootCommand = new("Simple command line app to search for a name in a csv file.");
        rootCommand.Options.Add(nameOption);


        ParseResult parseResult = rootCommand.Parse(args);
        if (parseResult.Errors.Count > 0)
        {
            foreach (ParseError parseError in parseResult.Errors)
            {
                Console.Error.WriteLine(parseError.Message);
            }

            return 1;
        }
        
        var services = CreateServices();
        
        ResultPrinter resultPrinter = services.GetRequiredService<ResultPrinter>();
        if (parseResult.GetValue(nameOption) is not { } searchName) return 0;
        if (string.IsNullOrWhiteSpace(searchName))
        {
            Console.Error.WriteLine("The --name option cannot be empty.");
            return 1;
        }

        resultPrinter.PrintResults(searchName);
        return 0;
    }
    
    private static ServiceProvider CreateServices()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IDatatReader, CsvDataReader>()
            .AddSingleton<IFilterService, FilterService>()
            .AddSingleton<ResultPrinter>()
            .BuildServiceProvider();

        return serviceProvider;
    }

    
}