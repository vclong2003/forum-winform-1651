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
        public override Post AddPost(Thread thread, string content)
        {
            throw new NotImplementedException();
        }

        public override Thread CreateThread(Subforum subforum, string title)
        {
            throw new NotImplementedException();
        }

        public override Post EditPost(Thread thread, string content)
        {
            throw new NotImplementedException();
        }
    }
}
