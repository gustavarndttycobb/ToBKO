using Microsoft.EntityFrameworkCore;
using InterviewBKO.Core.Entities;
using InterviewBKO.Infrastructure.Data;
using InterviewBKO.Infrastructure.Repositories;

namespace InterviewBKO.Tests;

public class UserRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly UserRepository _repository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _repository = new UserRepository(_context);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }

    #region GetAllAsync Tests

    [Fact]
    public async Task GetAllAsync_ReturnsAllUsers()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, Email = "user1@email.com", FullName = "User One", PasswordHash = "hash1", IsActive = true },
            new User { Id = 2, Email = "user2@email.com", FullName = "User Two", PasswordHash = "hash2", IsActive = true }
        };
        await _context.Users.AddRangeAsync(users);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }
    #endregion
}
