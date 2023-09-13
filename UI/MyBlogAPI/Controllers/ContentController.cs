using Microsoft.AspNetCore.Mvc;
using MyBlogAPI.Services.Interfaces;

namespace MyBlogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly IContentService  _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contents = await _contentService.GetContentsAsync();
        return Ok(contents);
    }

}
