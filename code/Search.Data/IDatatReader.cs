namespace Search.CsvInput;

public interface IDatatReader
{
    public IEnumerable<Camera> Read();
}