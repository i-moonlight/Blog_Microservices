

using AutoMapper;
using CommentAPI.Models;
using CommentAPI.Models.Dtos;

namespace CommentAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CommentUpdateDto>().ReverseMap();
        CreateMap<Comment, CommentCreateDto>().ReverseMap();
    }
}
