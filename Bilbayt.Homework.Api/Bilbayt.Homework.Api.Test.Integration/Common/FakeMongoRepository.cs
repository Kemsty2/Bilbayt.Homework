using Bilbayt.Homework.Api.Domain;
using Bilbayt.Homework.Api.Domain.Settings;
using Bilbayt.Homework.Api.Persistence.Repositories.Implementations;
using Microsoft.Extensions.Options;
using Mongo2Go;
using MongoDB.Driver;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace Bilbayt.Homework.Api.Test.Integration.Common
{
    public class FakeMongoRepository<TDocument> : MongoRepository<TDocument>, IDisposable where TDocument : BaseEntity
    {
        private readonly MongoDbRunner _runner;
        private readonly IMongoCollection<TDocument> _collection;

        public FakeMongoRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {
            var collectionName = GetCollectionName(typeof(TDocument));
            _runner = MongoDbRunner.Start();

            var database = new MongoClient(_runner.ConnectionString).GetDatabase("IntegrationTest");

            _collection = database.GetCollection<TDocument>(collectionName);
            ImportSeedData($"./Seeds/{collectionName}.txt");
        }

        public override Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public override Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public override Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public override Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public override Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public override Task<bool> IsExist(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.CountDocuments(filterExpression) > 0);
        }

        public void Dispose()
        {
            _runner.Dispose();
        }

        #region Private Methods

        private void ImportSeedData(string inputFileName)
        {
            using var streamReader = new StreamReader(inputFileName);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                using var jsonReader = new JsonReader(line);
                var context = BsonDeserializationContext.CreateRoot(jsonReader);
                var document = _collection.DocumentSerializer.Deserialize(context);
                _collection.InsertOne(document);
            }
        }

        #endregion Private Methods
    }
}