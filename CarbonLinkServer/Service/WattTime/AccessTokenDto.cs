using Newtonsoft.Json;

namespace CarbonLinkServer.Service.WattTime;

public class AccessTokenDto
{
    [JsonProperty("token")]
    public string? Token { get; set; }
}