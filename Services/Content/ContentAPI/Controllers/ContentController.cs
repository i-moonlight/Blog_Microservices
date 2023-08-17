using ContentAPI.Models.Dtos;
using ContentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace ContentAPI.Controllers;

[Authorize]
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

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var content = await _contentService.GetById(id);
        return CreateActionResultInstance(content);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(ContentCreateDto contentCreateDto)
    {
        var response = await _contentService.Create(contentCreateDto);

        return CreateActionResultInstance(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(ContentUpdateDto contentUpdateDto)
    {
        var response = await _contentService.Update(contentUpdateDto);
        return CreateActionResultInstance(response);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string contentId)
    {
        var response = await _contentService.Delete(contentId);
        return CreateActionResultInstance(response);
    }




}
