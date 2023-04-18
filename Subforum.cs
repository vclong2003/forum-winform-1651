using MongoDB.Bson;

namespace VCLForum
{
    internal class Subforum
    {
        public ObjectId Id { get; set; }
        public Moderator Creator { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public Subforum(Moderator creator, string title)
        {
            Creator = creator;
            Title = title;

            this.CreatedAt = DateTime.Now;
        }
    }
}
