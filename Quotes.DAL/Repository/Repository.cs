using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Quotes.Models;

namespace Quotes.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext db)
		{
            _db = db;
            this.dbSet = _db.Set<TEntity>();
        }


        public TEntity Get(long id)=> dbSet.Where(e => e.Id == id).First();
        


        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }


        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _db.Set<TEntity>().Attach(entity);
            _db.Entry<TEntity>(entity).State = EntityState.Deleted;
        }


      


        public void Update(TEntity entity)
        {

            _db.Set<TEntity>().Attach(entity);
            _db.Entry<TEntity>(entity).State = EntityState.Modified;

        }
    }
}

