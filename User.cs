using MongoDB.Bson;
using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    internal abstract class User
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? Dob { get; set; }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }

        public static bool Login<T>(string email, string password) where T : User //constraint to subclasses of User
        {
            var collection = DBHandler.Instance.Database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq(user => user.Email, email);

            T user;
            try
            {
                user = collection.Find(filter).First();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }

            if (password == user.Password)
            {
                Program.currentUser = user;
                if (user is Moderator) { Program.moderatorMode = true; }
                return true;
            }

            return false;
        }

        public abstract Thread CreateThread(Subforum subforum, string title);
        public abstract Post AddPost(Thread thread, string content);
        public abstract Post EditPost(Thread thread, string content);

    }
}
