namespace VCLForum
{
    internal class Participant : User
    {
        public bool IsBanned { get; set; }

        public Participant(string email, string password, string name)
            : base(email, password, name)
        {
        }
        public static bool Register(string email, string password)
        {
            return true;
        }
        public override Thread CreateThread(Subforum subforum, string title)
        {
            throw new NotImplementedException();
        }

        public override Post AddPost(Thread thread, string content)
        {
            throw new NotImplementedException();
        }

        public override Post EditPost(Thread thread, string content)
        {
            throw new NotImplementedException();
        }
    }
}
