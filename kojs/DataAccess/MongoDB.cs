using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using kojs.Models;
using MongoDB.Driver;

namespace kojs.DataAccess
{
    public class MongoDB
    {
        private MongoDatabase MongoDatabase { get; set; }
        private MongoClient MongoClient { get; set; }
        private MongoClientSettings Settings { get; set; }

        private const string ConnectionString = "mongodb://localhost:27017";

        public MongoDB(string dataBaseName)
        {
            Settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
            MongoClient = new MongoClient(Settings);
            var server = MongoClient.GetServer();
            MongoDatabase = server.GetDatabase(dataBaseName);
        }

        public bool CheckMongoConnection()
        {
            var server = MongoClient.GetServer();
            try
            {
                server.Connect();
                server.Disconnect();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Product> GetProducts()
        {
            return MongoDatabase.GetCollection<Product>("ProductsCollection").FindAll().ToList();
        }
    }
}