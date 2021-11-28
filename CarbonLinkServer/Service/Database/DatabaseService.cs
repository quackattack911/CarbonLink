﻿using MongoDB.Driver;

namespace CarbonLinkServer.Service.Database
{
    public class DatabaseService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoCollection<User> _users;

        public DatabaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            MongoClient mongoClient = new MongoClient(_configuration["MongoDb:ConnectionString"]);
            var database = mongoClient.GetDatabase(_configuration["MongoDb:DatabaseName"]);
            _users = database.GetCollection<User>(_configuration["MongoDb:CollectionName"]);
        }

        public User Get(string walletAddress) =>
            _users.Find(user => user.WalletAddress == walletAddress).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string walletAddress, User userIn) =>
            _users.ReplaceOne(user => user.WalletAddress == walletAddress, userIn);

        public void Remove(string walletAddress) =>
            _users.DeleteOne(user => user.WalletAddress == walletAddress);
    }
}
