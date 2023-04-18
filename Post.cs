using MongoDB.Bson;

namespace VCLForum
{
    internal class Post
    {
        public ObjectId Id { get; set; }
        public User Creator { get; set; }
        public Thread Thread { get; set; }
        public DateTime PostDate { get; set; }
        public string Content { get; set; }

        public Post(User creator, Thread thread, string content)
        {
            this.Creator = creator;
            this.Thread = thread;
            this.Content = content;

            this.PostDate = DateTime.Now;
        }
    }
}
