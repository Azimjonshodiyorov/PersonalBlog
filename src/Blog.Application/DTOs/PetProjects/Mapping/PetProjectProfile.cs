using AutoMapper;
using Blog.Application.DTOs.PetProject;
using Blog.Core.Entities;

namespace Blog.Application.DTOs.PetProjects.Mapping;

public class PetProjectProfile : Profile
{
    public PetProjectProfile()
    {
        CreateMap<Blog.Core.Entities.PetProject , PetProjectDto>().ReverseMap();
        CreateMap<Blog.Core.Entities.PetProject , CreatePetProjectDto>().ReverseMap();
        CreateMap<Blog.Core.Entities.PetProject , UpdatePetProjectDto>().ReverseMap();
        CreateMap<Blog.Core.Entities.PetProjectFile , PetProjectFileDto>().ReverseMap();
    }
}