using AutoMapper;
using Blog.Core.Entities;

namespace Blog.Application.DTOs.PetProjects.Mapping;

public class PetProjectProfile : Profile
{
    public PetProjectProfile()
    {
        CreateMap<PetProject , PetProjectDto>().ReverseMap();
        CreateMap<PetProject , CreatePetProjectDto>().ReverseMap();
        CreateMap<PetProject , CreatePetProjectDto>().ReverseMap();
        CreateMap<PetProject , UpdatePetProjectDto>().ReverseMap();
        CreateMap<PetProjectFile , PetProjectFileDto>().ReverseMap();
    }
}