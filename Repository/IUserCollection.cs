using MongoDB.Bson;
using PobreBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Repository
{
    public interface IUserCollection
    {
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(ObjectId id);
        Task<User> FindUser(string email);
        Task<Document> GetDocuments(Object _id);
        Task InsertDocuments(Document document, string id);
    }
}
