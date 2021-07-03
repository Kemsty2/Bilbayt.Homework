using Bilbayt.Homework.Api.Domain;
using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Domain.Settings;
using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Bilbayt.Homework.Api.Persistence.Repositories.Implementations
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : BaseEntity
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IOptions<MongoDbSettings> settings)
        {
            var database = new MongoClient(settings.Value.ConnectionString).GetDatabase(settings.Value.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public virtual Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public virtual Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public virtual Task<bool> IsExist(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.CountDocuments(filterExpression) > 0);
        }

        #region Private Methods

        protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        #endregion Private Methods
    }
}