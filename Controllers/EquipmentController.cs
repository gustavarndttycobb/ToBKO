using Microsoft.AspNetCore.Mvc;
using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Controllers;

[ApiController]
[Route("[controller]")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _equipmentService;
    private readonly ILogger<EquipmentController> _logger;

    public EquipmentController(IEquipmentService equipmentService, ILogger<EquipmentController> logger)
    {
        _equipmentService = equipmentService;
        _logger = logger;
    }

    [HttpGet(Name = "GetEquipments")]
    public async Task<ActionResult<List<EquipmentDto>>> GetEquipments()
    {
        var equipments = await _equipmentService.GetAllAsync();
        _logger.LogInformation("Returning {Count} equipments", equipments.Count);
        return Ok(equipments);
    }

    [HttpGet("{id}", Name = "GetEquipmentById")]
    public async Task<ActionResult<EquipmentDto>> GetEquipmentById(long id)
    {
        var equipment = await _equipmentService.GetByIdAsync(id);

        if (equipment == null)
        {
            _logger.LogWarning("Equipment with ID {Id} not found", id);
            return NotFound();
        }

        _logger.LogInformation("Returning equipment with ID {Id}", id);
        return Ok(equipment);
    }

    [HttpGet("facility/{facilityId}", Name = "GetEquipmentsByFacility")]
    public async Task<ActionResult<List<EquipmentDto>>> GetEquipmentsByFacility(long facilityId)
    {
        var equipments = await _equipmentService.GetByFacilityIdAsync(facilityId);
        _logger.LogInformation("Returning {Count} equipments for facility {FacilityId}", equipments.Count, facilityId);
        return Ok(equipments);
    }

    [HttpPost(Name = "CreateEquipment")]
    public async Task<ActionResult<EquipmentDto>> CreateEquipment([FromBody] CreateEquipmentDto equipmentDto)
    {
        var createdEquipment = await _equipmentService.CreateAsync(equipmentDto);
        return CreatedAtRoute("GetEquipmentById", new { id = createdEquipment.Id }, createdEquipment);
    }

    [HttpPut("{id}", Name = "UpdateEquipment")]
    public async Task<IActionResult> UpdateEquipment(long id, [FromBody] UpdateEquipmentDto equipmentDto)
    {
        await _equipmentService.UpdateAsync(id, equipmentDto);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteEquipment")]
    public async Task<IActionResult> DeleteEquipment(long id)
    {
        await _equipmentService.DeleteAsync(id);
        return NoContent();
    }
}