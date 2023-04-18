using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    internal class Moderator : User
    {
        public Moderator(string email, string password, string name)
            : base(email, password, name)
        {
        }
        public static Moderator? Login(string email, string password)
        {
            var moderatorCollection = DBHandler.Instance.Database.GetCollection<Moderator>("Moderator");
            var filter = Builders<Moderator>.Filter.Eq(mod => mod.Email, email);

            Moderator currentModerator;
            try
            {
                currentModerator = moderatorCollection.Find(filter).First();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return null;
            }

            if (password == currentModerator.Password)
            {
                return currentModerator;
            }
            return null;
        }
    }
}
