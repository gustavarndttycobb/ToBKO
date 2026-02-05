using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;
using WebApiProject.Data;

namespace WebApiProject.Controllers;

/// <summary>
/// Controller responsible for managing Facility resources.
/// </summary>
[ApiController]
[Route("[controller]")]
public class FacilityController : ControllerBase
{
    private readonly ILogger<FacilityController> _logger;
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the FacilityController.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="context">Database context.</param>
    public FacilityController(ILogger<FacilityController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    /// <summary>
    /// Retrieves all facilities.
    /// </summary>
    /// <returns>A list of all facilities.</returns>
    [HttpGet(Name = "GetFacilities")]
    public ActionResult<IEnumerable<Facility>> GetFacilities()
    {
        var facilities = _context.Facilities.ToList();
        _logger.LogInformation("Returning {Count} facilities", facilities.Count);
        return Ok(facilities);
    }

    /// <summary>
    /// Retrieves a specific facility by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the facility.</param>
    /// <returns>The facility if found; otherwise, a 404 Not Found response.</returns>
    [HttpGet("{id}", Name = "GetFacilityById")]
    public ActionResult<Facility> GetFacilityById(long id)
    {
        var facility = _context.Facilities.FirstOrDefault(f => f.Id == id);

        if (facility == null)
        {
            _logger.LogWarning("Facility with ID {Id} not found", id);
            return NotFound();
        }

        _logger.LogInformation("Returning facility with ID {Id}", id);
        return Ok(facility);
    }
}