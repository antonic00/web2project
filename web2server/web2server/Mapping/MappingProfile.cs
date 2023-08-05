using AutoMapper;
using web2server.Dtos;
using web2server.Models;

namespace web2server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Article, ArticleDto>().ReverseMap();
        }
    }
}
