using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Entities;

namespace InterviewBKO.Core.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> SignupAsync(SignupRequest request);
    Task<AuthResponse> SigninAsync(SigninRequest request);
}

public interface IFacilityService
{
    Task<List<FacilityDto>> GetAllAsync();
    Task<FacilityDto?> GetByIdAsync(long id);
    Task<FacilityDto> CreateAsync(CreateFacilityDto request);
    Task UpdateAsync(long id, UpdateFacilityDto request);
    Task DeleteAsync(long id);
}