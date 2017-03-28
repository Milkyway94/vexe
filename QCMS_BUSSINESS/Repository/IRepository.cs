using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;                  

namespace QCMS_BUSSINESS.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Remove(T entity);
        IQueryable<T> SearchFor(Expression<Func<T,bool>> predicate);
        IQueryable<T> All();
        T Find(int id);
        void Save();
    }
}
