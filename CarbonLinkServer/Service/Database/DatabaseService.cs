using MongoDB.Driver;
using CarbonLinkServer.Service.Database.Models;

namespace CarbonLinkServer.Service.Database
{
    public class DatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<User> _users;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
    }
}
