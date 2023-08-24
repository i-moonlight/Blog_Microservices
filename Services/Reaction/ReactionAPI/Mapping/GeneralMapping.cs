using AutoMapper;
using ReactionAPI.Models;
using ReactionAPI.Models.Dtos;

namespace ReactionAPI.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Like, LikeDto>().ReverseMap();
        CreateMap<Like, LikeCreateDto>().ReverseMap();
    }
}
