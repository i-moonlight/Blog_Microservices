using SharedLib.Dtos;

namespace ImageStoreAPI.Services;

public interface IImageService
{
    Task<Response<string>> UploadImage(IFormFile image);
}
