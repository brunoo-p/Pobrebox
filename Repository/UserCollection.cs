using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using PobreBox.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Repository
{
    public class UserCollection : IUserCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<User> Collection;

        public UserCollection()
        {
            Collection = _repository.database.GetCollection<User>("Users");
        }
        public async Task DeleteUser(ObjectId id)
        {
            var filter = Builders<User>.Filter.Eq(user => user.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<User> FindUser(string email)
        {
            try
            {
                return await Collection.FindAsync(
                    new BsonDocument { { "email", email } })
                    .Result
                    .FirstAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Document> GetDocuments(object _id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertDocuments(Document document, string id)
        {
            var filter = Builders<User>.Filter.Eq(user => user.Id, new ObjectId(id));
            var user = await Collection.FindAsync(filter);
            if(user != null)
            {
                
                Document doc = new Document()
                {
                    IdUser = new ObjectId(id),
                    Name = document.Name,
                    Directory = document.Directory,
                    File = File.ReadAllBytes(document.Name),
                };

                List<Document> addDoc = new List<Document> { doc };
            }

        }

        public async Task InsertUser(User user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await Collection.ReplaceOneAsync(filter, user);
        }
    }
}
