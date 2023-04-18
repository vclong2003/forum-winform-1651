using MongoDB.Bson;

namespace VCLForum
{
    internal abstract class User
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? Dob { get; set; }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
