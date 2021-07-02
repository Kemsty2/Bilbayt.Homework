using Bilbayt.Homework.Api.Domain;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bilbayt.Homework.Api.Persistence.Repositories.Contracts
{
    public interface IMongoRepository<TDocument> where TDocument : BaseEntity
    {
        Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task<TDocument> FindByIdAsync(string id);

        Task InsertOneAsync(TDocument document);

        Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression);

        Task DeleteByIdAsync(string id);

        Task<bool> IsExist(Expression<Func<TDocument, bool>> filterExpression);
    }
}