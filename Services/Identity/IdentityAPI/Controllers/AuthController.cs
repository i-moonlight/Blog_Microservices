using IdentityAPI.Models;
using IdentityAPI.Models.Dtos;
using IdentityAPI.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace IdentityAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : CustomBaseController
{
    private readonly IIdentityService _identityService;
    public AuthController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
    {
        var result = await _identityService.Login(loginRequestDto);
        return CreateActionResultInstance(result);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequestDto registerRequestDto)
    {
        var result = await _identityService.Register(registerRequestDto);
        return CreateActionResultInstance(result);
    }
}
