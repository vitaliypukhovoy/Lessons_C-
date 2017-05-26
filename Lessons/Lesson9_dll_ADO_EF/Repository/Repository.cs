using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;


namespace Lesson9_dll_ADO_EF_
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext m_context = null;
        DbSet<T> m_DbSet;
        public Repository(DbContext context)
        {
            m_context = context;
            m_DbSet = m_context.Set<T>();
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
           // m_context.Configuration.ProxyCreationEnabled = false;
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }
            return m_DbSet;
        }
        public T Get(Expression<Func<T, bool>> predicate = null)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }
        public void Add(T entity)
        {
            m_DbSet.Add(entity);
        }
        public void Udate(T entity)
        {
            m_DbSet.Attach(entity);
            // T entity = m_DbSet.Find(id);
            ((IObjectContextAdapter)m_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
      
        }

        public void Delete(T entity)
        {
            m_DbSet.Remove(entity);
            // m_DbSet.Entry(entity).State = System.Data.Entity.EntityState.Deleted;  
          //  ((IObjectContextAdapter)m_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
        }

        public long Count()
        {
            return m_DbSet.Count();
        }

    }
}
