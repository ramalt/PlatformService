using PlatformSerivce.Models;

namespace PlatformSerivce.Repositories;

public interface IPlatformRepository
{
    bool SaveChanges();
    IEnumerable<Platform> GetAllPlatforms();
    Platform GetPlatformById(int platformId);
    void CreatePlatform(Platform platform);
    



}
