namespace InterviewBKO.Application.DTOs;

public record SignupRequest(string Email, string Password, string FullName);
public record SigninRequest(string Email, string Password);
public record AuthResponse(string Token);