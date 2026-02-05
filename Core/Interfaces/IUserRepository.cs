using InterviewBKO.Core.Entities;

namespace InterviewBKO.Core.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(long id);
    Task<User?> GetByEmailAsync(string email);
    Task<bool> ExistsByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task SaveChangesAsync();
}