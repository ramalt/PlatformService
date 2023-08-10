using PlatformService.Models;

namespace PlatformService.Repositories;

public interface IPlatformRepository
{
    bool SaveChanges();
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int platformId);
    void CreatePlatform(Platform platform);
    



}
