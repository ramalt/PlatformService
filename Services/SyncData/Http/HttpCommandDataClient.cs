using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.Services.SyncData.Http;

public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task SendPlatformToCommand(ReadPlatformDto readPlatformDto)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(readPlatformDto),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync($"{_configuration["CommandServiceEndpoint"]}", httpContent);
        Console.WriteLine(_configuration["CommandServiceEndpoint"]);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("🙌 -> Sync POST to CommandService OK!");
        }
        else
        {
            Console.WriteLine("🧐 -> Request was not OK.");

        }
    }
}
