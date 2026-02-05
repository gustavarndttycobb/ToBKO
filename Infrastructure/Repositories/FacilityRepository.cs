using Microsoft.EntityFrameworkCore;
using InterviewBKO.Core.Entities;
using InterviewBKO.Core.Interfaces;
using InterviewBKO.Infrastructure.Data;

namespace InterviewBKO.Infrastructure.Repositories;

public class FacilityRepository : IFacilityRepository
{
    private readonly AppDbContext _context;

    public FacilityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Facility>> GetAllAsync()
    {
        return await _context.Facilities.ToListAsync();
    }

    public async Task<Facility?> GetByIdAsync(long id)
    {
        return await _context.Facilities.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task AddAsync(Facility facility)
    {
        await _context.Facilities.AddAsync(facility);
    }

    public Task UpdateAsync(Facility facility)
    {
        _context.Facilities.Update(facility);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Facility facility)
    {
        _context.Facilities.Remove(facility);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}