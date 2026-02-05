using InterviewBKO.Core.Entities;

namespace InterviewBKO.Core.Interfaces;

public interface IFacilityRepository
{
    Task<List<Facility>> GetAllAsync();
    Task<Facility?> GetByIdAsync(long id);
    Task AddAsync(Facility facility);
    Task UpdateAsync(Facility facility);
    Task DeleteAsync(Facility facility);
    Task SaveChangesAsync();
}