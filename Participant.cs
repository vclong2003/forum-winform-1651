﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Diagnostics;

namespace VCLForum
{
    [BsonDiscriminator("Participant")]
    internal class Participant : User
    {
        public bool IsBanned { get; set; }

        public Participant(string email, string password, string name)
            : base(email, password, name) { }

        public static bool Register(string name, string email, string password)
        {
            var collection = DBHandler.Instance.Database.GetCollection<Participant>(typeof(Participant).Name);
            var filter = Builders<Participant>.Filter.Eq(user => user.Email, email);
            var cursor = collection.Find(filter);

            if (cursor.Any()) return false; // User exsisted

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            try { collection.InsertOne(new Participant(email, hashedPassword, name)); }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
