using AutoMapper;
using Blog.Core.Entities;

namespace Blog.Application.DTOs.Post.Mapping;

public class PostProfile : Profile
{
    public PostProfile()
    {
        CreateMap<Core.Entities.Post, PostDto>().ReverseMap();
        CreateMap<PostFile, PostFileDto>().ReverseMap();
        CreateMap<Core.Entities.Post, CreatePostDto>().ReverseMap();
        CreateMap<Core.Entities.Post, UpdatePostDto>().ReverseMap();
    }
}