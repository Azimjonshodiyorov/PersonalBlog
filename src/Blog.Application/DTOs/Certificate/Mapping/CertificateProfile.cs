using AutoMapper;
using Blog.Application.DTOs.Certificates;

namespace Blog.Application.DTOs.Certificate.Mapping;

public class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        CreateMap<Core.Entities.Certificate, CreateCertificateDto>().ReverseMap();
        CreateMap<Core.Entities.Certificate, CertificateDto>().ReverseMap();
        CreateMap<Core.Entities.Certificate, UpdateCertificateDto>().ReverseMap();
        CreateMap<Core.Entities.CertificateFile, CertificateFileDto>().ReverseMap();
        CreateMap<Core.Entities.Certificate, CertificateDto>();
    }
}