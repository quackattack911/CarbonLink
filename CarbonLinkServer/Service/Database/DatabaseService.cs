using MongoDB.Driver;

namespace CarbonLinkServer.Service.Database
{
    public class DatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<DbUser> _users;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            MongoClient mongoClient = new MongoClient(_configuration["MongoDb:ConnectionString"]);
            var database = mongoClient.GetDatabase(_configuration["MongoDb:DatabaseName"]);
            _users = database.GetCollection<DbUser>(_configuration["MongoDb:CollectionName"]);
        }

        public DbUser Get(string walletAddress) =>
            _users.Find(user => user.WalletAddress == walletAddress).FirstOrDefault();

        public DbUser Create(DbUser user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, DbUser userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

        public IEnumerable<DbUser> GetChargingUsers() =>
            _users.Find(user => user.ChargingInProgress).ToEnumerable();

        public void StartCharging(string id) =>
            _users.UpdateOne(user => user.Id == id, Builders<DbUser>.Update.Set("ChargingInProgress", true));

        public void StopCharging(string id) =>
            _users.UpdateOne(user => user.Id == id, Builders<DbUser>.Update.Set("ChargingInProgress", false));
    }
}
