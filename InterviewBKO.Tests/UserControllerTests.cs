using InterviewBKO.Application.DTOs;
using InterviewBKO.Controllers;
using InterviewBKO.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace InterviewBKO.Tests;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _controller = new UserController(_userServiceMock.Object);
    }

    #region GetAll Tests

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithListOfUsers()
    {
        // Arrange
        var users = new List<UserDto>
        {
            new UserDto(1, "user1@email.com", "User One", true),
            new UserDto(2, "user2@email.com", "User Two", true)
        };
        _userServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
        Assert.Equal(2, returnedUsers.Count);
        _userServiceMock.Verify(s => s.GetAllAsync(), Times.Once);
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WithEmptyList_WhenNoUsersExist()
    {
        // Arrange
        _userServiceMock.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<UserDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUsers = Assert.IsType<List<UserDto>>(okResult.Value);
        Assert.Empty(returnedUsers);
        _userServiceMock.Verify(s => s.GetAllAsync(), Times.Once);
    }

    #endregion

    #region GetById Tests

    [Fact]
    public async Task GetById_ReturnsOkResult_WithUser_WhenUserExists()
    {
        // Arrange
        var user = new UserDto(1, "user1@email.com", "User One", true);
        _userServiceMock.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(user);

        // Act
        var result = await _controller.GetById(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedUser = Assert.IsType<UserDto>(okResult.Value);
        Assert.Equal(1, returnedUser.Id);
        Assert.Equal("user1@email.com", returnedUser.Email);
        Assert.Equal("User One", returnedUser.FullName);
        Assert.True(returnedUser.IsActive);
        _userServiceMock.Verify(s => s.GetByIdAsync(1), Times.Once);
    }

    [Fact]
    public async Task GetById_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        _userServiceMock.Setup(s => s.GetByIdAsync(999)).ReturnsAsync((UserDto?)null);

        // Act
        var result = await _controller.GetById(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
        _userServiceMock.Verify(s => s.GetByIdAsync(999), Times.Once);
    }

    [Fact]
    public async Task GetById_CallsServiceWithCorrectId()
    {
        // Arrange
        var userId = 42L;
        var user = new UserDto(userId, "test@email.com", "Test User", true);
        _userServiceMock.Setup(s => s.GetByIdAsync(userId)).ReturnsAsync(user);

        // Act
        await _controller.GetById(userId);

        // Assert
        _userServiceMock.Verify(s => s.GetByIdAsync(userId), Times.Once);
    }

    #endregion

    #region Delete Tests

    [Fact]
    public async Task Delete_ReturnsNoContent_WhenDeleteSucceeds()
    {
        // Arrange
        _userServiceMock.Setup(s => s.DeleteAsync(1)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
        _userServiceMock.Verify(s => s.DeleteAsync(1), Times.Once);
    }

    [Fact]
    public async Task Delete_CallsServiceWithCorrectId()
    {
        // Arrange
        var userId = 123L;
        _userServiceMock.Setup(s => s.DeleteAsync(userId)).Returns(Task.CompletedTask);

        // Act
        await _controller.Delete(userId);

        // Assert
        _userServiceMock.Verify(s => s.DeleteAsync(userId), Times.Once);
    }

    [Fact]
    public async Task Delete_ReturnsNoContent_ForAnyValidId()
    {
        // Arrange
        var userId = 999L;
        _userServiceMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.Delete(userId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    #endregion
}
