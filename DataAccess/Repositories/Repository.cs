using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : UnityOfWork where TEntity : class
    {
        public Repository(MedicalContext context) 
            : base(context)
        {

        }

        public IEnumerable<TEntity> getAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity getById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> searchFor(Expression<Func<TEntity, bool>> query)
        {
            return context.Set<TEntity>().Where(query);
        }

        public void add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void delete(int id)
        {
            var entity = context.Set<TEntity>().Find(id);

            context.Set<TEntity>().Remove(entity);
        }
    }
}
