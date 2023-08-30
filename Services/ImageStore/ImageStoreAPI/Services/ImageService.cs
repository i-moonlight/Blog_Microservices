using SharedLib.Dtos;

namespace ImageStoreAPI.Services;

public class ImageService : IImageService
{
    private static readonly string ImageUploadPath = "Uploads";
    public async Task<Response<string>> UploadImage(IFormFile file)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        string filePath = Path.Combine("wwwroot", ImageUploadPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return Response<string>.Success("/Uploads/"+fileName,200);
    }
}
