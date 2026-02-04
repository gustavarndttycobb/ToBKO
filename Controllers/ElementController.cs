using Microsoft.AspNetCore.Mvc;

namespace InterviewBKO.Controllers;

[ApiController]
[Route("api/elements")]
public class ElementController : ControllerBase
{
    private readonly List<Elements> elements = new List<Elements>([
        new Elements
        {
            Id = 1,
            Name = "Element 1",
            Children = new List<Elements>
            {
                new Elements { Id = 2, Name = "Element 1.1", ParentId = "1" },
                new Elements { Id = 3, Name = "Element 1.2", ParentId = "1" }
            }
        },
        new Elements
        {
            Id = 4,
            Name = "Element 2",
            Children = new List<Elements>
            {
                new Elements { Id = 5, Name = "Element 2.1", ParentId = "4" },
                new Elements { Id = 6, Name = "Element 2.2", ParentId = "4" }
            }
        }
    ]);
    private readonly ILogger<ElementController> _logger;

    public ElementController(ILogger<ElementController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetElements")]
    public IEnumerable<Elements> GetElements()
    {
        return elements;
    }
}
