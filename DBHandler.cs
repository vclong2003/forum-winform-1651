using MongoDB.Driver;
using System.Diagnostics;

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

        public void Test()
        {
            var modCollection = Database.GetCollection<Moderator>("Moderator");
            var sCollection = Database.GetCollection<Subforum>("Subforum");
            var tCollection = Database.GetCollection<Thread>("Thread");
            var pCollection = Database.GetCollection<Post>("Post");

            Moderator newMod = new Moderator("vclong2003@gmail.com", "123456aA@", "vcl");
            modCollection.InsertOne(newMod);

            Subforum s = new Subforum(newMod, "Test");
            sCollection.InsertOne(s);

            Thread t = new Thread(newMod, s, "Test thread");
            tCollection.InsertOne(t);

            Post p = new Post(newMod, t, "New post");
            pCollection.InsertOne(p);

            Debug.WriteLine(newMod.Id);

        }
    }
}
