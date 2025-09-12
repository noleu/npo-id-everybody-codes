using Search.CsvInput;

namespace Search.Service;

public class FilterService(IDatatReader dataReader) : IFilterService
{
    public IEnumerable<Camera> FilterByName(string name)
    {
        try
        {
            var cameras = dataReader.Read();
            return cameras.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Camera> NoFilter()
    {
        try
        {
            return dataReader.Read();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}