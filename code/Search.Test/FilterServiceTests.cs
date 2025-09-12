using Search.CsvInput;
using Search.Service;

namespace Search.Test;

public class FilterServiceTests
{
    private class TestDataReader : IDatatReader
    {
        private readonly IEnumerable<Camera> _cameras = new List<Camera>
        {
            new ("Camera1", 0, 0),
            new ("Camera2", 0, 0),
            new ("AnotherCamera", 0, 0)
        };
        
        public IEnumerable<Camera> Read()
        {
            return _cameras;
        }
    }
    
    private class TestDataReaderEmpty : IDatatReader
    {
        public IEnumerable<Camera> Read() => new List<Camera>();
    }

    [Fact]
    public void TestFindOccurence()
    {
        
        // Arrange
        IDatatReader dataReader = new TestDataReader();
        var filterService = new FilterService(dataReader);

        // Act
        var result = filterService.FilterByName("Another").ToList();

        // Assert
        Assert.Single(result);
        Assert.All(result, c => Assert.Contains("Another", c.Name, StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void TestFindNothing()
    {
        // Arrange
        IDatatReader dataReader = new TestDataReader();
        var filterService = new FilterService(dataReader);

        // Act
        var result = filterService.FilterByName( "Nothing").ToList();

        // Assert
        Assert.Empty(result);
    }
    
    [Fact]
    public void TestFindMultiple()
    {
        // Arrange
        IDatatReader dataReader = new TestDataReader();
        var filterService = new FilterService(dataReader);

        // Act
        var result = filterService.FilterByName( "Camera").ToList();

        // Assert
        Assert.Equal(3, result.Count);
        Assert.All(result, c => Assert.Contains("Camera", c.Name, StringComparison.OrdinalIgnoreCase));
    }
    
    [Fact]
    public void TestHandleEmptyInput()
    {
        var cameras = new List<Camera>();
        // Arrange
        IDatatReader dataReader = new TestDataReaderEmpty();
        
        var filterService = new FilterService(dataReader);

        // Act
        var result = filterService.FilterByName("Another").ToList();

        // Assert
        Assert.Empty(result);
    }
}