using Bilbayt.Homework.Api.Persistence.Documents;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Persistence.Repositories.Contracts
{
    public interface IMongoRepository<TDocument> where TDocument : IBaseDocument
    {
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindByIdAsync(string id);

        Task InsertOneAsync(TDocument document);

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task DeleteByIdAsync(string id);
    }
}