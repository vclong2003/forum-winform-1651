using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    internal class DBHandler
    {
        private static DBHandler? instance;
        private MongoClient client;
        public IMongoDatabase Database { get; private set; }

        private DBHandler()
        {
            this.client = new MongoClient("mongodb+srv://vclong2003:88888888@main.q9qhhu6.mongodb.net/?retryWrites=true&w=majority");

            this.Database = client.GetDatabase("vclforum");
        }

        public static DBHandler GetInstance()
        {
            if (instance == null) { instance = new DBHandler(); }
            return instance;
        }

        public static void CloseConnection()
        {
            if (instance == null) { return; }

            instance.client.Cluster.Dispose();
            instance = null;
            Debug.WriteLine("Connection closed!");
        }
    }
}