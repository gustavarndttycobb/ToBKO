using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(u => new UserDto(u.Id, u.Email, u.FullName, u.IsActive)).ToList();
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException($"User with ID {id} not found.");

        return new UserDto(user.Id, user.Email, user.FullName, user.IsActive);
    }

    public async Task DeleteAsync(long id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new KeyNotFoundException($"User with ID {id} not found.");

        user.IsActive = false;
        await _userRepository.UpdateAsync(user);
        await _userRepository.SaveChangesAsync();
    }
}