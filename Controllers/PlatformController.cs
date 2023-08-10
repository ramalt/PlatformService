using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Repositories;

namespace PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepository _platformRepository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
    {
        _platformRepository = platformRepository;
        _mapper = mapper;
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
    public ActionResult<ReadPlatformDto> CreatePlatform(CreatePlatformDto createPlatformDto)
    {
        var platformModel = _mapper.Map<Platform>(createPlatformDto);

        _platformRepository.CreatePlatform(platformModel);
        _platformRepository.SaveChanges();

        var created = _mapper.Map<ReadPlatformDto>(platformModel);
        return Ok(created);

    }
}
