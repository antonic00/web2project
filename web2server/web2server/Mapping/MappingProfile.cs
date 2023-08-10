using AutoMapper;
using web2server.Dtos;
using web2server.Models;

namespace web2server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponseDto>();
            CreateMap<RegisterRequestDto, User>();
            CreateMap<UserRequestDto, User>();
            CreateMap<User, VerificationResponseDto>();
            CreateMap<VerificationRequestDto, User>();
            CreateMap<Article, ArticleResponseDto>();
            CreateMap<Article, DeleteResponseDto>();
            CreateMap<ArticleRequestDto, Article>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<Order, DeleteResponseDto>();
            CreateMap<OrderRequestDto, Order>();
        }
    }
}
