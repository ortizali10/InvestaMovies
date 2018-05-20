using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace InvestaMovies.Repo
{
    /// <summary>
    ///  Generic repository to make these method reusable to other entities/context
    /// </summary>
    /// <typeparam name="TContext">DbContext</typeparam>
    public class Repository<TContext> : IRepository
    where TContext : DbContext
    {
        protected readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get<TEntity>(string id) where TEntity : class
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Getall<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Getall<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}