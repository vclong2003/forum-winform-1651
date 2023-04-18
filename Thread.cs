using MongoDB.Bson;

namespace VCLForum
{
    internal class Thread
    {
        public ObjectId Id { get; set; }
        public User Creator { get; set; }
        public Subforum Subforum { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }

        public int postCount;
        public int viewCount;

        public Thread(User creator, Subforum subforum, string title)
        {
            Creator = creator;
            Subforum = subforum;
            Title = title;

            this.CreatedAt = DateTime.Now;
        }
    }
}
