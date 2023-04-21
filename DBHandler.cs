﻿using MongoDB.Driver;

namespace VCLForum
{
    internal class DBHandler
    {
        private static DBHandler instance = new DBHandler();
        public static DBHandler Instance { get { return instance; } }
        public IMongoDatabase Database { get; private set; }

        private DBHandler()
        {
            var client = new MongoClient("mongodb+srv://vclong2003:vclongMongo@cluster0.ipteima.mongodb.net/?retryWrites=true&w=majority");
            this.Database = client.GetDatabase("vclforum");
        }
    }
}