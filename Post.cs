using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VCLForum
{
    internal class Post
    {
        public ObjectId Id { get; set; }
        public User Creator { get; set; }
        public Thread Thread { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime PostDate { get; set; }

        public string Content { get; set; }

        public Post(User creator, Thread thread, string content)
        {
            this.Creator = creator;
            this.Thread = thread;
            this.Content = content;

            this.PostDate = DateTime.UtcNow.ToLocalTime();
        }
    }
}
