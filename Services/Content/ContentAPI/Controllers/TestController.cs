using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentAPI.Controllers;


[ApiController]
[Route("api/[controller]")]

public class TestController : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("asdasd");
    }

}
