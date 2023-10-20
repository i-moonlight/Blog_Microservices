
using CategoryAPI.Models.Dtos;
using CategoryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace ContentAPI.Controllers;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class CategoryController : CustomBaseController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var contents = await _categoryService.GetAll();
        return CreateActionResultInstance(contents);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var content = await _categoryService.GetById(id);
        return CreateActionResultInstance(content);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
    {
        var response = await _categoryService.Create(categoryCreateDto);

        return CreateActionResultInstance(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
    {
        var response = await _categoryService.Update(categoryUpdateDto);
        return CreateActionResultInstance(response);
    }


    [HttpDelete("Delete")]
    public async Task<IActionResult> Delete(string contentId)
    {
        var response = await _categoryService.Delete(contentId);
        return CreateActionResultInstance(response);
    }




}
