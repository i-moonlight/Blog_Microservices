using ImageStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLib.ControllerBases;

namespace ImageStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : CustomBaseController
{

    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var response = await _imageService.UploadImage(file);
        return CreateActionResultInstance(response);
    }

}
