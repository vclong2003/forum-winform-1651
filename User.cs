using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Participant), typeof(Moderator))]
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

            bool passwordVerify = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (passwordVerify)
            {
                Program.currentUser = user;
                if (user is Moderator) { Program.moderatorMode = true; }
                return true;
            }

            return false;
        }
        public Thread CreateThread(Subforum subforum, string title)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Thread>("Thread");

            Thread newThread = new(this, subforum, title);
            collection.InsertOne(newThread);

            return newThread;
        }
        public Post AddPost(Thread thread, string content)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Post>("Post");

            Post newPost = new(this, thread, content);
            collection.InsertOne(newPost);

            return newPost;
        }
        public Post EditPost(Post post, string content)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Post>("Post");

            if (post.Creator.Id != this.Id)
            {
                throw new InvalidOperationException("Not your post!");
            }

            var filter = Builders<Post>.Filter.Eq(p => p.Id, post.Id);
            var update = Builders<Post>.Update.Set(p => p.Content, content);
            var options = new FindOneAndUpdateOptions<Post> { ReturnDocument = ReturnDocument.After };

            return collection.FindOneAndUpdate(filter, update, options);
        }

    }
}
