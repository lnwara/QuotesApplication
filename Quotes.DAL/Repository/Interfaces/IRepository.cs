using System;
using System.Linq.Expressions;
using Quotes.Models;

namespace Quotes.DAL.Repository
{
	public interface IRepository<TEntity> where TEntity : BaseModel
    {
        TEntity Get(long id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null);
        void Update(TEntity entity);
    }
}

