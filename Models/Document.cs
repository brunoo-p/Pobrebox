using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Models
{
    public class Document
    {
        [BsonElement("idUser")]
        public ObjectId IdUser { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("directory")]
        public string Directory { get; set; }

        [BsonElement("file")]
        public Byte[] File { get; set; }
        
    }
}
