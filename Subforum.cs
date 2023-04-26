using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VCLForum
{
    internal class Subforum
    {
        public ObjectId Id { get; set; }
        public Moderator Creator { get; set; }
        public string Title { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        public Subforum(Moderator creator, string title)
        {
            Creator = creator;
            Title = title;

            this.CreatedAt = DateTime.UtcNow.ToLocalTime();
        }
    }
}
