using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QCMS_BUSSINESS.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext DataContext;
        protected DbSet<T> DbSet;

        abstract protected void SetUp(DbContext dataContext);

        public T Add(T entity)
        {
            return DbSet.Add(entity);
        }

        public IQueryable<T> All()
        {
            return DbSet;
        }

        public T Find(int id)
        {
            return DbSet.Find(id);
        }

        public T Remove(T entity)
        {
            return DbSet.Remove(entity);
        }

        public void Save()
        {
            DataContext.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
    }
}
