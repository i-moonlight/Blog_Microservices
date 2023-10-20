using System.Net;
using AutoMapper;
using CategoryAPI.Models;
using CategoryAPI.Models.Dtos;
using CategoryAPI.Models.Settings;
using MongoDB.Driver;
using SharedLib.Dtos;

namespace CategoryAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }

    public async Task<Response<NoContent>> Create(CategoryCreateDto categoryCreateDto)
    {
        var content= _mapper.Map<Category>(categoryCreateDto);
        await _categoryCollection.InsertOneAsync(content);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public async Task<Response<NoContent>> Delete(string id)
    {
        await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public async Task<Response<List<CategoryDto>>> GetAll()
    {
        var categories = await _categoryCollection.FindSync(category => true).ToListAsync();
        var categoriesDtos=_mapper.Map<List<CategoryDto>>(categories);
        return Response<List<CategoryDto>>.Success(categoriesDtos, (int)HttpStatusCode.OK);
    }

    public async Task<Response<CategoryDto>> GetById(string id)
    {
        var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        var categoryDto=_mapper.Map<CategoryDto>(category);
        return Response<CategoryDto>.Success(categoryDto, (int)HttpStatusCode.OK);
    }

    public async Task<Response<NoContent>> Update(CategoryUpdateDto categoryUpdateDto)
    {
        var category=_mapper.Map<Category>(categoryUpdateDto);
        await _categoryCollection.ReplaceOneAsync(category => category.Id == categoryUpdateDto.Id, category);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }
}
