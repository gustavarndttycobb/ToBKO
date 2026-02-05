namespace InterviewBKO.Application.DTOs;

public record UserDto(long Id, string Email, string FullName, bool IsActive);
public record UpdateUserDto(string FullName, bool IsActive);