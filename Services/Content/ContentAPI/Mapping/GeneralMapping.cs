using AutoMapper;
using ContentAPI.Models;
using ContentAPI.Models.Dtos;

namespace ContentAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Content, ContentDto>().ReverseMap();
        CreateMap<Content, ContentCreateDto>().ReverseMap();
        CreateMap<Content, ContentUpdateDto>().ReverseMap();
    }
}
