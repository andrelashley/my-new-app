using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    

    public class DataAccess
    {

        MongoClient _client;
        IMongoDatabase _db;
        public DataAccess(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            _db = _client.GetDatabase(databaseName);
        }

        public List<Models.Widget> GetWidgets()
        {
            return _db.GetCollection<Models.Widget>("Widgets").Find(new BsonDocument()).ToList();
        }

        public Models.Widget CreateWidget(Models.Widget c)
        {
            _db.GetCollection<Models.Widget>("Widgets").InsertOne(c);
            return c;
        }
    }
}
