using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Repositories;
using PlatformService.Services.SyncData.Http;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _platformRepository;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;

    public PlatformController(IPlatformRepository platformRepository, IMapper mapper, ICommandDataClient commandDataClient)
    {
        _platformRepository = platformRepository;
        _mapper = mapper;
        _commandDataClient = commandDataClient;

    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadPlatformDto>> GetPlatforms()
    {
        var platforms = _platformRepository.GetAllPlatforms();

        //ℹ️ platfroms -> IEnumerable<ReadPlatformDto> 
        var mapped = _mapper.Map<IEnumerable<ReadPlatformDto>>(platforms);

        return Ok(mapped);
    }

    [HttpGet("{id}")]
    public ActionResult<ReadPlatformDto> GetPlatformById(int id)
    {
        var platform = _platformRepository.GetPlatformById(id);
        if (platform != null)
        {
            //ℹ️ platfroms -> IEnumerable<ReadPlatformDto> 
            var mapped = _mapper.Map<ReadPlatformDto>(platform);

            return Ok(mapped);
        }

        return NotFound();
    }

    [HttpPost]//🚩returns mapped readPlatformDto type.
    public async Task<ActionResult<ReadPlatformDto>> CreatePlatform(CreatePlatformDto createPlatformDto)
    {
        var platformModel = _mapper.Map<Platform>(createPlatformDto);

        _platformRepository.CreatePlatform(platformModel);
        _platformRepository.SaveChanges();

        var created = _mapper.Map<ReadPlatformDto>(platformModel);

        try
        {
            await _commandDataClient.SendPlatformToCommand(created);
        }
        catch (Exception e)
        {

            Console.WriteLine($"❌ -> Could not send SYNC: {e.Message}");
        }

        return Ok(created);

    }
}
