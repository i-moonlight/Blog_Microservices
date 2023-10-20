using CategoryAPI.Models.Dtos;
using SharedLib.Dtos;

namespace CategoryAPI.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAll();
        Task<Response<CategoryDto>> GetById(string id);
        Task<Response<NoContent>> Create(CategoryCreateDto categoryCreateDto);
        Task<Response<NoContent>> Update(CategoryUpdateDto categoryUpdateDto);
        Task<Response<NoContent>> Delete(string id);
    }
}