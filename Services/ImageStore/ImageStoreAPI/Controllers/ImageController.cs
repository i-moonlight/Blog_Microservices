using ImageStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Minio;
using Minio.DataModel.Args;
using SharedLib.ControllerBases;

namespace ImageStoreAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImageController : CustomBaseController
{
    private readonly IImageService _imageService;
    private readonly IMinioClient _minioClient;
    public ImageController(IImageService imageService, IMinioClient minioClient)
    {
        _imageService = imageService;
        _minioClient = minioClient;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var response = await _imageService.UploadImage(file);
        return CreateActionResultInstance(response);
    }

    [HttpPost("uploadv2")]
    public async Task<IActionResult> UploadImagev2(IFormFile file)
    {   

        MemoryStream filestream = new MemoryStream();
        file.CopyTo(filestream);
        var filename = Guid.NewGuid();

        await _minioClient.PutObjectAsync(new PutObjectArgs()
                            .WithBucket("image").WithFileName(filename.ToString())
                            .WithStreamData(filestream).WithObjectSize(filestream.Length));

        return Ok("asd");
    }

}
