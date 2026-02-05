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
        var response = await _authService.SignupAsync(newUser);
        return CreatedAtAction(nameof(Signup), new { email = newUser.Email }, response);
    }


    [HttpPost("signin")]
    public async Task<IActionResult> Signin([FromBody] SigninRequest credentials)
    {
        var response = await _authService.SigninAsync(credentials);
        return Ok(response);
    }
}