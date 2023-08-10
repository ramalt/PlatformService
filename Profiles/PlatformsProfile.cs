using AutoMapper;
using PlatformSerivce.Dtos;
using PlatformSerivce.Models;

namespace PlatformSerivce.Profiles;

public class PlatformsProfile : Profile
{
    public PlatformsProfile()
    {
        //ℹ️ Mapping data between model and dto's.*️⃣
        CreateMap<Platform, ReadPlatformDto>();
        CreateMap<CreatePlatformDto, Platform>();
    }
}
