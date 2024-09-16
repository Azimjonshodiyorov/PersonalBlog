using AutoMapper;
using Blog.Core.Entities;

namespace Blog.Application.DTOs.PetProjects.Mapping;

public class PetProjectProfile : Profile
{
    public PetProjectProfile()
    {
        CreateMap<Blog.Core.Entities.PetProject , PetProjectDto>().ReverseMap();
        CreateMap<Blog.Core.Entities.PetProject , CreatePetProjectDto>().ReverseMap();
        CreateMap<Blog.Core.Entities.PetProject , UpdatePetProjectDto>().ReverseMap();
        CreateMap<PetProjectFile , PetProjectFileDto>().ReverseMap();
    }
}