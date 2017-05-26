using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace Lesson9_dll_ADO_EF_
{

    public  class ContextDB : DbContext
    {    
       public ContextDB() 
           : base("CarDB")
       {
          this.Configuration.LazyLoadingEnabled = false;
           Database.SetInitializer(new Initializer());
       }    
        public DbSet<Car> Cars { get; set; }       
    }
}
