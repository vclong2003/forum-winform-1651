using MongoDB.Driver;

namespace VCLForum
{
    internal class Participant : User
    {
        public bool IsBanned { get; set; }

        public Participant(string email, string password, string name)
            : base(email, password, name)
        {
        }
        public static Participant? Login(string email, string password)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Participant>("Participant");
            var filter = Builders<Participant>.Filter.Eq(par => par.Email, email);

            Participant user = collection.Find(filter).FirstOrDefault();

            if (password == user.Password)
            {
                return user;
            }

            return null;
        }

    }
}
