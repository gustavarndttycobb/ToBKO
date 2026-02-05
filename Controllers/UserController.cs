using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        return Ok(await _userService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(long id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}