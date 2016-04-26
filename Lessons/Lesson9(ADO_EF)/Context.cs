using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace Lesson9_ADO_EF_
{

    public  class ContextDB : DbContext
    {    
       public ContextDB() 
           : base("CarDB")
       {
         // this.Configuration.LazyLoadingEnabled = false;
          //Database.SetInitializer(new Initializer());
       }    
        public DbSet<Car> Cars { get; set; }       
    }


 
   public class Car
    {
        public int Id { get; set; }
        public string NameCar { get; set; }
        public string Color { get; set; }
        public string TypeCar { get; set; }
    }
}
