using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarbonLinkServer.Service.Database
{
    public class DbUser
    {
        public DbUser()
        {
            Id = ObjectId.GenerateNewId().ToString();
            ChargingInProgress = false;
            Balance = 0;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string WalletAddress { get; set; }

        public bool ChargingInProgress { get; set; }

        public string TeslaToken { get; set; }

        public string TeslaId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Balance { get; set; }

        public double ChargeAdded { get; set; }
    }
}
