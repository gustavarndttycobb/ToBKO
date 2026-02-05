using InterviewBKO.Core.Entities;

namespace InterviewBKO.Core.Interfaces;

public interface IEquipmentRepository
{
    Task<List<Equipment>> GetAllAsync();
    Task<List<Equipment>> GetByFacilityIdAsync(long facilityId);
    Task<Equipment?> GetByIdAsync(long id);
    Task AddAsync(Equipment equipment);
    Task UpdateAsync(Equipment equipment);
    Task DeleteAsync(Equipment equipment);
    Task SaveChangesAsync();
}