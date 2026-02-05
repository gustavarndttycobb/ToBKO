using Microsoft.EntityFrameworkCore;
using InterviewBKO.Core.Entities;
using InterviewBKO.Core.Interfaces;
using InterviewBKO.Infrastructure.Data;

namespace InterviewBKO.Infrastructure.Repositories;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly AppDbContext _context;

    public EquipmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Equipment>> GetAllAsync()
    {
        return await _context.Equipments.ToListAsync();
    }

    public async Task<List<Equipment>> GetByFacilityIdAsync(long facilityId)
    {
        return await _context.Equipments.Where(e => e.FacilityId == facilityId).ToListAsync();
    }

    public async Task<Equipment?> GetByIdAsync(long id)
    {
        return await _context.Equipments.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(Equipment equipment)
    {
        await _context.Equipments.AddAsync(equipment);
    }

    public Task UpdateAsync(Equipment equipment)
    {
        _context.Equipments.Update(equipment);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Equipment equipment)
    {
        _context.Equipments.Remove(equipment);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}