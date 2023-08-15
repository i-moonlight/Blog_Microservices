using ContentAPI.Models.Dtos;
using ContentAPI.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace ContentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : CustomBaseController
{
    private readonly IContentService _contentService;

    public ContentController(IContentService contentService)
    {
        _contentService = contentService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contents = await _contentService.GetAll();
        return CreateActionResultInstance(contents);
    }


    [HttpPost("Create")]
    public async Task<IActionResult> Create(ContentCreateDto contentCreateDto)
    {
        var response = await _contentService.Create(contentCreateDto);

        return CreateActionResultInstance(response);
    }



}
