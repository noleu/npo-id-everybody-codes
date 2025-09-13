using CsvHelper.Configuration;

namespace Search.CsvInput;

public class Camera(string id, string name, decimal latitude, decimal longitude, int number)
{
    public string Id { get; init; } = id;
    public string Name { get; init; } = name;
    public decimal Latitude { get; init; } = latitude;
    public decimal Longitude { get; init;} = longitude;
    public int Number { get; init; } = number;
}