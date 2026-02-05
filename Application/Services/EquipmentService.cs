using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Entities;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Application.Services;

public class EquipmentService : IEquipmentService
{
    private readonly IEquipmentRepository _repository;

    public EquipmentService(IEquipmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<EquipmentDto>> GetAllAsync()
    {
        var equipments = await _repository.GetAllAsync();
        return equipments.Select(e => new EquipmentDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            SerialNumber = e.SerialNumber,
            IsOperational = e.IsOperational,
            FacilityId = e.FacilityId
        }).ToList();
    }

    public async Task<List<EquipmentDto>> GetByFacilityIdAsync(long facilityId)
    {
        var equipments = await _repository.GetByFacilityIdAsync(facilityId);
        return equipments.Select(e => new EquipmentDto
        {
            Id = e.Id,
            Name = e.Name,
            Description = e.Description,
            SerialNumber = e.SerialNumber,
            IsOperational = e.IsOperational,
            FacilityId = e.FacilityId
        }).ToList();
    }

    public async Task<EquipmentDto?> GetByIdAsync(long id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment == null) return null;

        return new EquipmentDto
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Description = equipment.Description,
            SerialNumber = equipment.SerialNumber,
            IsOperational = equipment.IsOperational,
            FacilityId = equipment.FacilityId
        };
    }

    public async Task<EquipmentDto> CreateAsync(CreateEquipmentDto request)
    {
        var equipment = new Equipment
        {
            Name = request.Name,
            Description = request.Description,
            SerialNumber = request.SerialNumber,
            IsOperational = request.IsOperational,
            FacilityId = request.FacilityId
        };

        await _repository.AddAsync(equipment);
        await _repository.SaveChangesAsync();

        return new EquipmentDto
        {
            Id = equipment.Id,
            Name = equipment.Name,
            Description = equipment.Description,
            SerialNumber = equipment.SerialNumber,
            IsOperational = equipment.IsOperational,
            FacilityId = equipment.FacilityId
        };
    }

    public async Task UpdateAsync(long id, UpdateEquipmentDto request)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment == null) throw new KeyNotFoundException($"Equipment with ID {id} not found.");

        equipment.Name = request.Name;
        equipment.Description = request.Description;
        equipment.SerialNumber = request.SerialNumber;
        equipment.IsOperational = request.IsOperational;

        await _repository.UpdateAsync(equipment);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var equipment = await _repository.GetByIdAsync(id);
        if (equipment != null)
        {
            await _repository.DeleteAsync(equipment);
            await _repository.SaveChangesAsync();
        }
    }
}