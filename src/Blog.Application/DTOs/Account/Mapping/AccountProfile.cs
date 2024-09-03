using AutoMapper;

namespace Blog.Application.DTOs.Account.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Core.Entities.User, LoginDto>().ReverseMap();
        CreateMap<Core.Entities.User, RegistrationDto>().ReverseMap();
    }
}