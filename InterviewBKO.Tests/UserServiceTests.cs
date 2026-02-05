using InterviewBKO.Application.DTOs;
using InterviewBKO.Application.Services;
using InterviewBKO.Core.Entities;
using InterviewBKO.Core.Interfaces;
using Moq;

namespace InterviewBKO.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ReturnsListOfUserDtos()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Email = "user1@email.com", FullName = "User One", IsActive = true },
            new User { Id = 2, Email = "user2@email.com", FullName = "User Two", IsActive = true }
        };
        _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("user1@email.com", result[0].Email);
        Assert.Equal("User One", result[0].FullName);
        Assert.True(result[0].IsActive);
        _userRepositoryMock.Verify(r => r.GetAllAsync(), Times.Once);
    }

    #endregion
}
