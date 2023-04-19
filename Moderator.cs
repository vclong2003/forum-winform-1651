namespace VCLForum
{
    internal class Moderator : User
    {
        public Moderator(string email, string password, string name)
            : base(email, password, name)
        {
        }
        public Subforum CreateSubforum(string title)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Subforum>("Subforum");

            Subforum newSubforum = new(this, title);
            collection.InsertOne(newSubforum);

            return newSubforum;
        }

        public override Post EditPost(Thread thread, string content)
        {
            throw new NotImplementedException();
        }
    }
}
