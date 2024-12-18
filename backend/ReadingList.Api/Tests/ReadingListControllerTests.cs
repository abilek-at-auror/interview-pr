using Microsoft.AspNetCore.Mvc;
using Moq;
using ReadingListApi.Controllers;
using ReadingListApi.Models;
using ReadingListApi.Services;
using Xunit;

public class ReadingListControllerTests
{
    private readonly Mock<ReadingListService> _mockService;
    private readonly ReadingListController _controller;

    public ReadingListControllerTests()
    {
        // Create a mock service
        _mockService = new Mock<ReadingListService>();
        
        // Inject the mock service into the controller
        _controller = new ReadingListController(_mockService.Object);
    }

    [Fact]
    public void AddReadingItem_ReturnsCreatedResult()
    {
        // Arrange
        var newItem = new ReadingItem { Title = "Test Book", Author = "Test Author", Genre = "Fiction", IsRead = false };

        // Configure the mock service to add the item
        _mockService.Setup(service => service.AddItem(newItem)).Returns(newItem);

        // Act
        var result = _controller.AddItem(newItem);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(newItem, createdResult.Value);
        _mockService.Verify(service => service.AddItem(newItem), Times.Once); // Verify AddItem was called
    }

    [Fact]
    public void AddReadingItem_ReturnsBadRequest_IfMissingFields()
    {
        // Arrange
        var invalidItem = new ReadingItem { Title = "", Author = "" };

        // Act
        var result = _controller.AddItem(invalidItem);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
        _mockService.Verify(service => service.AddItem(It.IsAny<ReadingItem>()), Times.Never); // Ensure service is not called
    }
}