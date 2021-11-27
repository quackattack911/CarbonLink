using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla;

public class TeslaService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TeslaService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task WakeVehicle(string accessToken, string id)
    {
        string wakeRoute = $"api/1/vehicles/{id}/wake_up";
        HttpClient httpClient = CreateTeslaClient(accessToken);
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(wakeRoute, null);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Wake Up Failed!");
        }
        return;
    }

    public async Task<ChargeStateDto?> GetChargeState(string accessToken, string id)
    {
        string chargeRoute = $"api/1/vehicles/{id}/data_request/charge_state";
        HttpClient httpClient = CreateTeslaClient(accessToken);
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(chargeRoute);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Get Charge State Failed!");
        }
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        ChargeStateDto? chargeState = JsonConvert.DeserializeObject<ChargeStateDto>(responseContent, settings);
        return chargeState;
    }

    public async Task<DriveStateDto?> GetDriveState(string accessToken, string id)
    {
        string driveRoute = $"api/1/vehicles/{id}/data_request/drive_state";
        HttpClient httpClient = CreateTeslaClient(accessToken);
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(driveRoute);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Get Drive State Failed!");
        }
        string responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
        DriveStateDto? driveStateDto = JsonConvert.DeserializeObject<DriveStateDto>(responseContent, settings);
        return driveStateDto;
    }

    private HttpClient CreateTeslaClient(string accessToken)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("Tesla");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return httpClient;
    }
}