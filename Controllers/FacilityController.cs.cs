using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<IEnumerable<Facility>> GetFacilities()
    {
        var facilities = _context.Facilities.ToList();
        _logger.LogInformation("Returning {Count} facilities", facilities.Count);
        return Ok(facilities);
    }

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