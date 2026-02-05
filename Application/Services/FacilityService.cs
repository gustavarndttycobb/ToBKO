using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Entities;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Application.Services;

public class FacilityService : IFacilityService
{
    private readonly IFacilityRepository _repository;

    public FacilityService(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FacilityDto>> GetAllAsync()
    {
        var facilities = await _repository.GetAllAsync();
        return facilities.Select(f => new FacilityDto
        {
            Id = f.Id,
            Name = f.Name,
            IsWorking = f.IsWorking,
            TimeRunning = f.TimeRunning,
            Equipments = f.Equipments.Select(e => new EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                SerialNumber = e.SerialNumber,
                IsOperational = e.IsOperational,
                FacilityId = e.FacilityId
            }).ToList(),
            ParentId = f.ParentId,
            Children = f.Children.Select(c => new FacilityDto
            {
                Id = c.Id,
                Name = c.Name,
                IsWorking = c.IsWorking,
                TimeRunning = c.TimeRunning,
                ParentId = c.ParentId
            }).ToList()
        }).ToList();
    }

    public async Task<FacilityDto?> GetByIdAsync(long id)
    {
        var facility = await _repository.GetByIdAsync(id);
        if (facility == null) return null;

        return new FacilityDto
        {
            Id = facility.Id,
            Name = facility.Name,
            IsWorking = facility.IsWorking,
            TimeRunning = facility.TimeRunning,
            Equipments = facility.Equipments.Select(e => new EquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                SerialNumber = e.SerialNumber,
                IsOperational = e.IsOperational,
                FacilityId = e.FacilityId
            }).ToList(),
            ParentId = facility.ParentId,
            Children = facility.Children.Select(c => new FacilityDto
            {
                Id = c.Id,
                Name = c.Name,
                IsWorking = c.IsWorking,
                TimeRunning = c.TimeRunning,
                ParentId = c.ParentId
            }).ToList()
        };
    }

    public async Task<FacilityDto> CreateAsync(CreateFacilityDto request)
    {
        var facility = new Facility
        {
            Name = request.Name,
            IsWorking = request.IsWorking,
            TimeRunning = request.TimeRunning,
            ParentId = request.ParentId
        };

        await _repository.AddAsync(facility);
        await _repository.SaveChangesAsync();

        return new FacilityDto
        {
            Id = facility.Id,
            Name = facility.Name,
            IsWorking = facility.IsWorking,
            TimeRunning = facility.TimeRunning
        };
    }

    public async Task UpdateAsync(long id, UpdateFacilityDto request)
    {
        var facility = await _repository.GetByIdAsync(id);
        if (facility == null) throw new KeyNotFoundException($"Facility with ID {id} not found.");

        facility.Name = request.Name;
        facility.IsWorking = request.IsWorking;
        facility.TimeRunning = request.TimeRunning;
        facility.ParentId = request.ParentId;

        await _repository.UpdateAsync(facility);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var facility = await _repository.GetByIdAsync(id);
        if (facility != null)
        {
            await _repository.DeleteAsync(facility);
            await _repository.SaveChangesAsync();
        }
    }
}