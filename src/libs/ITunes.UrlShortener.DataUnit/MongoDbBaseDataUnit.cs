using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace ITunes.UrlShortener.DataUnit
{
    public abstract class MongoDbBaseDataUnit<T>: IBaseDataUnit<T> where T: class
    {
        private readonly IMongoCollection<T> _mongoCollection;

        protected MongoDbBaseDataUnit(string mongoDbConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDbConnectionString);
            var database = client.GetDatabase(dbName);
            _mongoCollection = database.GetCollection<T>(collectionName);
        }


        public IList<T> List()
        {
            return _mongoCollection.Find(m => true).ToList();
        }
        
        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _mongoCollection.Find(predicate).FirstOrDefault();
        }

        public void Add(T entity)
        {
            _mongoCollection.InsertOne(entity);
        }
    }
}