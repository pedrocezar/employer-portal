using EmployerPortal.Application.Contracts.Responses;
using EmployerPortal.Application.Services.Interfaces;
using EmployerPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployerPortal.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployerController(IUserService _userService) : ControllerBase
{
    [HttpGet("{username}")]
    [ProducesResponseType(200, Type = typeof(UserResponse))]
    [ProducesResponseType(400, Type = typeof(ErrorResponse))]
    [ProducesResponseType(404, Type = typeof(ErrorResponse))]
    [ProducesResponseType(500, Type = typeof(ErrorResponse))]
    public async Task<IActionResult> Welcome(string username)
    {
        var result = await _userService.WelcomeUserAsync(username);
        return Ok(result);
    }
}