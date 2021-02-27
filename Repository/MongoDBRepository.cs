using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Repository
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase database;

        public MongoDBRepository()
        {
            try
            {
                client = new MongoClient("mongodb+srv://brunoo-p:" +
                "false@cluster.oyyye.mongodb.net/Pobrebox?retryWrites=true&w=majority");
                database = client.GetDatabase("Pobrebox");
                Console.WriteLine("API Started");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}
