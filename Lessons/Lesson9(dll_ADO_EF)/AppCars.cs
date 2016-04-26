using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Dynamic;
using System.Data.Entity;

namespace Lesson9_dll_ADO_EF_
{
   public class AppCars
    {
        private DbContext context;
        public AppCars(DbContext _db)
        {
            this.context = _db;
        }     
        public  void AddCar(Car car )
        {
            using (UnitOfWork db = new UnitOfWork(context))
            {
                var listCars = db.Cars.GetAll().ToList();
                foreach (var item in listCars)
                    Console.WriteLine(item.NameCar);             
            }                      
        }

        public void RemoveCar(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork db = new UnitOfWork(context))
                {
                    var car = db.Cars.Get(i => i.Id == Id);
                    db.Cars.Delete(car);
                    db.SaveChange();
                    Console.WriteLine("You have just removed car {0}", car.NameCar);
                }
            }
            else
            {
                Console.WriteLine("Invalid Car");
            }          
        }
        public void FindCar(int? Id)
        {
            
          if (Id != null)
            {
            using (UnitOfWork db = new UnitOfWork(context))
            {
                var car = db.Cars.Get(i => i.Id == Id);
                if (car != null)
                {
                    Console.WriteLine(" You have finded car {0}", car.NameCar);
                }    
            }
            }
               else
             {
              Console.WriteLine("Invalid Car");
             }            
        }
    }
}
