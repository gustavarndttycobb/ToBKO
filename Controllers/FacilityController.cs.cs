using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;
using WebApiProject.Data;

namespace WebApiProject.Controllers;

[ApiController]
[Route("[controller]")]
public class FacilityController : ControllerBase
{
    private readonly ILogger<FacilityController> _logger;
    private readonly AppDbContext _context;

    public FacilityController(ILogger<FacilityController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetFacilities")]
    public async Task<ActionResult<IEnumerable<Facility>>> GetFacilities()
    {
        var facilities = await _context.Facilities.ToListAsync();
        _logger.LogInformation("Returning {Count} facilities", facilities.Count);
        return Ok(facilities);
    }

    [HttpGet("{id}", Name = "GetFacilityById")]
    public async Task<ActionResult<Facility>> GetFacilityById(long id)
    {
        var facility = await _context.Facilities.FirstOrDefaultAsync(f => f.Id == id);

        if (facility == null)
        {
            _logger.LogWarning("Facility with ID {Id} not found", id);
            return NotFound();
        }

        _logger.LogInformation("Returning facility with ID {Id}", id);
        return Ok(facility);
    }

    [HttpPost(Name = "CreateFacility")]
    public async Task<ActionResult<Facility>> CreateFacility([FromBody] Facility facility)
    {
        facility.Id = 0;

        await _context.Facilities.AddAsync(facility);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created facility with ID {Id}", facility.Id);

        return CreatedAtRoute("GetFacilityById", new { id = facility.Id }, facility);
    }

    [HttpPut("{id}", Name = "UpdateFacility")]
    public async Task<IActionResult> UpdateFacility(long id, [FromBody] Facility facility)
    {
        if (id != facility.Id)
        {
            return BadRequest("Facility ID mismatch");
        }

        var existingFacility = await _context.Facilities.FirstOrDefaultAsync(f => f.Id == id);
        if (existingFacility == null)
        {
            _logger.LogWarning("Facility with ID {Id} not found for update", id);
            return NotFound();
        }

        existingFacility.Name = facility.Name;
        existingFacility.IsWorking = facility.IsWorking;
        existingFacility.TimeRunning = facility.TimeRunning;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Updated facility with ID {Id}", id);

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteFacility")]
    public async Task<IActionResult> DeleteFacility(long id)
    {
        var facility = await _context.Facilities.FirstOrDefaultAsync(f => f.Id == id);
        if (facility == null)
        {
            _logger.LogWarning("Facility with ID {Id} not found for deletion", id);
            return NotFound();
        }

        _context.Facilities.Remove(facility);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted facility with ID {Id}", id);

        return NoContent();
    }
}