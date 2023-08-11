using IdentityAPI.Models;
using IdentityAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
    {
        var result = await _identityService.Login(loginRequestModel);
        return Ok(result);
    }
}
