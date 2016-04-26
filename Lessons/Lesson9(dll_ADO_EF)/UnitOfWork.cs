using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lesson9_dll_ADO_EF_
{
    public class UnitOfWork : IDisposable
    {
        private DbContext m_context = null;        
        private Repository<Car> car;
      
        public UnitOfWork(DbContext context)
        {
            m_context = context;
        }
        public Repository<Car> Cars
        {
            get
            {
                if (car == null)
                {
                    car = new Repository<Car>(m_context);
                }
                return car;
            }
        }
        public void SaveChange()
        {
            m_context.SaveChanges();
        }

        bool disposed = true;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                m_context.Dispose();
            }

            disposed = true;
        }
    }
}
