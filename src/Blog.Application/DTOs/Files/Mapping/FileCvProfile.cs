using AutoMapper;
using Blog.Core.Entities;

namespace Blog.Application.DTOs.Files.Mapping;

public class FileCvProfile : Profile
{
    public FileCvProfile()
    {
        CreateMap<FileCv, FileCvDto>().ReverseMap();
        CreateMap<FileCv, FileCvDto>();
        CreateMap<FileCv, UpdateFileCvDto>().ReverseMap();
    }
}