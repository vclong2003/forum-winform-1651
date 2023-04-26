using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VCLForum
{
    internal class Thread
    {
        public ObjectId Id { get; set; }
        public User Creator { get; set; }
        public Subforum Subforum { get; set; }
        public string Title { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        public Thread(User creator, Subforum subforum, string title)
        {
            Creator = creator;
            Subforum = subforum;
            Title = title;

            this.CreatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
