using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarbonLinkServer.Service.Database
{
    public class DbUser
    {
        public DbUser()
        {
            Id = ObjectId.GenerateNewId();
            ChargingInProgress = false;
            Balance = 0;
        }

        [BsonId]
        public ObjectId Id { get; set; }

        public string WalletAddress { get; set; }

        public bool ChargingInProgress { get; set; }

        public string TeslaToken { get; set; }

        public string TeslaId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Balance { get; set; }
    }
}
