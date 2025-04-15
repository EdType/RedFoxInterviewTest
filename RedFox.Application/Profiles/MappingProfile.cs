#region

using AutoMapper;
using RedFox.Application.DTO;
using RedFox.Domain.Entities;

#endregion

namespace RedFox.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Company, CompanyDto>();
        CreateMap<Address, AddressDto>();
        CreateMap<Geo, GeoDto>();

        CreateMap<UserCreationDto, User>()
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<CompanyDto, Company>()
            .ForMember(dest => dest.User, opt => opt.Ignore());

        CreateMap<AddressDto, Address>()
            .ForMember(dest => dest.User, opt => opt.Ignore());

        CreateMap<GeoDto, Geo>()
            .ForMember(dest => dest.Address, opt => opt.Ignore());
    }
}