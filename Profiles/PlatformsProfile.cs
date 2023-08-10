using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        //ℹ️ Mapping data between model and dto's.*️⃣
        CreateMap<Platform, ReadPlatformDto>();
        CreateMap<CreatePlatformDto, Platform>();
    }
}
