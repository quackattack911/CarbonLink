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

    private HttpClient CreateTeslaClient(string accessToken)
    {
        HttpClient httpClient = _httpClientFactory.CreateClient("Tesla");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return httpClient;
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
        ChargeStateDto? chargeState = JsonConvert.DeserializeObject<ChargeStateResponseDto>(responseContent, settings).Response;
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
        DriveStateDto? driveStateDto = JsonConvert.DeserializeObject<DriveStateResponseDto>(responseContent, settings).Response;
        return driveStateDto;
    }

    public async Task StartCharging(string accessToken, string id)
    {
        string startChargeRoute = $"api/1/vehicles/{id}/command/charge_start";
        HttpClient httpClient = CreateTeslaClient(accessToken);
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(startChargeRoute, null);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Charge Start Failed!");
        }
        return;
    }

    public async Task StopCharging(string accessToken, string id)
    {
        string stopChargeRoute = $"api/1/vehicles/{id}/command/charge_stop";
        HttpClient httpClient = CreateTeslaClient(accessToken);
        HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(stopChargeRoute, null);
        if (!httpResponseMessage.IsSuccessStatusCode && httpResponseMessage.Content == null)
        {
            throw new Exception("Charge Start Failed!");
        }
        return;
    }

    public async Task ResetChargeState(string accessToken, string id)
    {
        await StopCharging(accessToken, id);
        Thread.Sleep(10000);
        await StartCharging(accessToken, id);
        Thread.Sleep(10000);
        await StopCharging(accessToken, id);
    }
}