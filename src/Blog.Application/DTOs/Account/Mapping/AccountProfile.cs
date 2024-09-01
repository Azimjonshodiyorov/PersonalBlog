using AutoMapper;

namespace Blog.Application.DTOs.Account.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Core.Entities.User, LoginDto>();
        CreateMap<Core.Entities.User, RegistrationDto>();
    }
}