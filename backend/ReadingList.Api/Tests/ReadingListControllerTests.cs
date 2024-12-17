using Microsoft.AspNetCore.Mvc;
using ReadingListApi.Controllers;
using ReadingListApi.Models;
using Xunit;

public class ReadingListControllerTests
{
    [Fact]
    public void AddReadingItem_ReturnsCreatedResult()
    {
        // Arrange
        var controller = new ReadingListController();
        var newItem = new ReadingItem { Title = "Test Book", Author = "Test Author", Genre = "Fiction", IsRead = false };

        // Act
        var result = controller.AddReadingItem(newItem);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public void AddReadingItem_ReturnsBadRequest_IfMissingFields()
    {
        var controller = new ReadingListController();
        var newItem = new ReadingItem { Title = "", Author = "" };

        var result = controller.AddReadingItem(newItem);

        Assert.IsType<BadRequestObjectResult>(result);
    }
}
