using System.Globalization;
using CsvHelper; 
namespace Search.CsvInput;

public class CsvDataReader : IDatatReader
{
    public IEnumerable<Camera> Read() 
    {
        using var reader = new StreamReader("data/cameras-defb.csv");
        var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            Delimiter = ";"
        };
        var cameras = new List<Camera>();
        using var csv = new CsvReader(reader, config);
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            if (!csv.GetField("Camera")!.ToString().StartsWith("UTR"))
            {
                continue; // Skip this record if the condition is not met
            }

            var record = new Camera(
                csv.GetField<string>("Camera") ?? string.Empty,
                csv.GetField<decimal>("Latitude"),
                csv.GetField<decimal>("Longitude"));
                    
            cameras.Add(record);
        }
        return cameras;
    }
    
}