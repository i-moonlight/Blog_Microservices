using CommentAPI.Models.Dtos;
using CommentAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace CommentControllerAPI.Controllers;

[ApiController]
// [Authorize]
[Route("api/[controller]")]
public class CommentController : CustomBaseController
{
private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contents = await _commentService.GetAll();
        return CreateActionResultInstance(contents);
    }

    [HttpGet("GetAllByContentId")]
    public async Task<IActionResult> GetAllByContentId(string contentId)
    {
        var contents = await _commentService.GetAllByContentId(contentId);
        return CreateActionResultInstance(contents);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var content = await _commentService.GetById(id);
        return CreateActionResultInstance(content);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CommentCreateDto commentCreateDto)
    {
        var response = await _commentService.Create(commentCreateDto);
        return CreateActionResultInstance(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
    {
        var response = await _commentService.Update(commentUpdateDto);
        return CreateActionResultInstance(response);
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string contentId)
    {
        var response = await _commentService.Delete(contentId);
        return CreateActionResultInstance(response);
    }
}
