using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Lesson9_dll_ADO_EF_
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate = null);
        void Add(T entity);
        void Udate(T entity);
        void Delete(T entity);
        long Count();

    }
}
