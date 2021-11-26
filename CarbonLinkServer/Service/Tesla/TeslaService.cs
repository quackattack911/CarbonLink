using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla;

public class TeslaService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _accessToken;
    private readonly string _id;

    public TeslaService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _accessToken = _configuration["Tesla:AccessToken"];
        _id = _configuration["Tesla:Id"];
    }

    public async Task WakeVehicle()
    {
        string wakeRoute = $"api/1/vehicles/{_id}/wake_up";
        var httpClient = _httpClientFactory.CreateClient("Tesla");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        var httpResponseMessage = await httpClient.PostAsync(wakeRoute, null);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Wake Up Failed!");
        }
        return;
    }

    public async Task<ChargeStateDto> GetChargeState()
    {
        string chargeRoute = $"api/1/vehicles/{_id}/data_request/charge_state";
        var httpClient = _httpClientFactory.CreateClient("Tesla");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        var httpResponseMessage = await httpClient.GetAsync(chargeRoute);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Get Charge State Failed!");
        }
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        ChargeStateDto chargeState = JsonConvert.DeserializeObject<ChargeStateDto>(responseContent, settings);
        return chargeState;
    }

    public async Task<DriveStateDto> GetDriveState()
    {
        string driveRoute = $"api/1/vehicles/{_id}/data_request/drive_state";
        var httpClient = _httpClientFactory.CreateClient("Tesla");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);
        var httpResponseMessage = await httpClient.GetAsync(driveRoute);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Get Drive State Failed!");
        }
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        DriveStateDto driveStateDto = JsonConvert.DeserializeObject<DriveStateDto>(responseContent, settings);
        return driveStateDto;
    }
}