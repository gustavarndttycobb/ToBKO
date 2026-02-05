using Microsoft.AspNetCore.Mvc;
using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Controllers;

[ApiController]
[Route("[controller]")]
[Microsoft.AspNetCore.Authorization.Authorize]
public class FacilityController : ControllerBase
{
    private readonly IFacilityService _facilityService;
    private readonly ILogger<FacilityController> _logger;

    public FacilityController(IFacilityService facilityService, ILogger<FacilityController> logger)
    {
        _facilityService = facilityService;
        _logger = logger;
    }

    [HttpGet(Name = "GetFacilities")]
    public async Task<ActionResult<List<FacilityDto>>> GetFacilities()
    {
        var facilities = await _facilityService.GetAllAsync();
        _logger.LogInformation("Returning {Count} facilities", facilities.Count);
        return Ok(facilities);
    }

    [HttpGet("{id}", Name = "GetFacilityById")]
    public async Task<ActionResult<FacilityDto>> GetFacilityById(int id)
    {
        var facility = await _facilityService.GetByIdAsync(id);

        if (facility == null)
        {
            _logger.LogWarning("Facility with ID {Id} not found", id);
            return NotFound();
        }

        _logger.LogInformation("Returning facility with ID {Id}", id);
        return Ok(facility);
    }

    [HttpPost(Name = "CreateFacility")]
    public async Task<ActionResult<FacilityDto>> CreateFacility([FromBody] CreateFacilityDto facilityDto)
    {
        var createdFacility = await _facilityService.CreateAsync(facilityDto);
        return CreatedAtRoute("GetFacilityById", new { id = createdFacility.Id }, createdFacility);
    }

    [HttpPut("{id}", Name = "UpdateFacility")]
    public async Task<IActionResult> UpdateFacility(int id, [FromBody] UpdateFacilityDto facilityDto)
    {
        try
        {
            await _facilityService.UpdateAsync(id, facilityDto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteFacility")]
    public async Task<IActionResult> DeleteFacility(int id)
    {
        await _facilityService.DeleteAsync(id);
        return NoContent();
    }
}