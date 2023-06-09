﻿using MongoDB.Bson.Serialization.Attributes;

namespace VCLForum
{
    [BsonDiscriminator("Moderator")]
    internal class Moderator : User
    {
        public Moderator(string email, string password, string name)
            : base(email, password, name) { }

        public Subforum CreateSubforum(string title)
        {
            var collection = DBHandler.GetInstance().Database.GetCollection<Subforum>(typeof(Subforum).Name);

            Subforum newSubforum = new(this, title);
            collection.InsertOne(newSubforum);

            return newSubforum;
        }
    }
}
