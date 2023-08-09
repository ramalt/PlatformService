using AutoMapper;
using PlatformSerivce.Dtos;
using PlatformSerivce.Models;

namespace PlatformSerivce.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        CreateMap<Platform, ReadPlatformDto>();
        CreateMap<CreatePlatformDto, Platform>();
    }
}
