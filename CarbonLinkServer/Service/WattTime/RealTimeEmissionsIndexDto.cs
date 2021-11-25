using Newtonsoft.Json;

namespace CarbonLinkServer.Service.WattTime;

public class RealTimeEmissionsIndexDto
{
    [JsonProperty("freq")]
    public int? Frequency { get; set; }

    [JsonProperty("ba")]
    public string? BalancingAuthority { get; set; }

    [JsonProperty("percent")]
    public byte? Percent { get; set; }

    [JsonProperty("moer")]
    public int? Moer { get; set; }

    [JsonProperty("point_time")]
    public DateTime? PointTime { get; set; }
}