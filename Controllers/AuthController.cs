using Microsoft.AspNetCore.Mvc;
using InterviewBKO.Application.DTOs;
using InterviewBKO.Core.Interfaces;

namespace InterviewBKO.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> Signup([FromBody] SignupRequest newUser)
    {
        try
        {
            var response = await _authService.SignupAsync(newUser);
            return CreatedAtAction(nameof(Signup), new { email = newUser.Email }, response);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("signin")]
    public async Task<IActionResult> Signin([FromBody] SigninRequest credentials)
    {
        try
        {
            var response = await _authService.SigninAsync(credentials);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }

}