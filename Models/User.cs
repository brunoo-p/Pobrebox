using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        
        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonRequired]
        [BsonElement("password")]
        public string Password { get; set; }

        [BsonRequired]
        [BsonElement("isActive")]
        [BsonDefaultValue(true)]
        public bool IsActive { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}
