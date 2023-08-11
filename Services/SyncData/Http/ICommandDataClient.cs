using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.Services.SyncData.Http;

public interface ICommandDataClient
{
    Task SendPlatformToCommand(ReadPlatformDto readPlatformDto);
}
