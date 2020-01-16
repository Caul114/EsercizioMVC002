using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogMongoDB.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public string Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
