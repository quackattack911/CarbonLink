using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla
{
    public class DriveStateResponseDto
    {
        [JsonProperty("response")]
        public DriveStateDto Response { get; set; }
    }

    public class DriveStateDto
    {
        [JsonProperty("gps_as_of")]
        public long? GpsAsOf { get; set; }

        [JsonProperty("heading")]
        public long? Heading { get; set; }

        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }

        [JsonProperty("native_latitude")]
        public double? NativeLatitude { get; set; }

        [JsonProperty("native_latitude_supported")]
        public bool? NativeLatitudeSupported { get; set; }

        [JsonProperty("native_longitude")]
        public double? NativeLongitude { get; set; }

        [JsonProperty("native_type")]
        public string? NativeType { get; set; }

        [JsonProperty("power")]
        public long? Power { get; set; }

        [JsonProperty("shift_state")]
        public string? ShiftState { get; set; }

        [JsonProperty("speed")]
        public long? Speed { get; set; }

        [JsonProperty("timestamp")]
        public long? TimeStamp { get; set; }
    }
}
