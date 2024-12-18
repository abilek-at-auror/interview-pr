using System.Linq;
using Xunit;
using ReadingListApi.Services;
using ReadingListApi.Models;

public class ReadingListServiceTests
{
    [Fact]
    public void AddItem_ShouldAddNewItem()
    {
        // Arrange
        var service = new ReadingListService();
        var newItem = new ReadingItem { Title = "Test Book", Author = "Test Author", Genre = "Test Genre", IsRead = false };

        // Act
        var addedItem = service.AddItem(newItem);

        // Assert
        Assert.NotNull(addedItem);
        Assert.Equal("Test Book", addedItem.Title);
        Assert.Contains(addedItem, service.GetAllItems());
    }
}
