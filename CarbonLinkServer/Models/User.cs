using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarbonLinkServer.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string WalletAddress { get; set; }

        public bool ChargingInProgress { get; set; }

        public string TeslaToken { get; set; }

        public string TeslaId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Balance { get; set; }
    }
}
