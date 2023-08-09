using PlatformSerivce.Data;
using PlatformSerivce.Models;

namespace PlatformSerivce.Repositories;

public class PlatformRepository : IPlatformRepository
{
    private readonly AppDbContext _context;

    public PlatformRepository(AppDbContext context)
    {
        _context = context;
    }

    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new NotImplementedException(nameof(platform));
        }

        _context.Platforms.Add(platform);

    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int platformId)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == platformId);

    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
