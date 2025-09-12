using CsvHelper.Configuration;

namespace Search.CsvInput;

public class Camera(string name, decimal latitude, decimal longitude)
{
    public string Name { get; init; } = name;
    public decimal Latitude { get; init; } = latitude;
    public decimal Longitude { get; init;} = longitude;
}