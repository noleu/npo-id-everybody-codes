using Search.CsvInput;

namespace Search.Service;

public interface IFilterService
{ 
    public IEnumerable<Camera> FilterByName(string name);
    public IEnumerable<Camera> NoFilter();
}