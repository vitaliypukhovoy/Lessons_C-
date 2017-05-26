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

        public  void GetCar()
        {
            using (UnitOfWork db = new UnitOfWork(context))
            {
                var listCars = db.Cars.GetAll().ToList();
                if (listCars != null)
                {
                    foreach (var item in listCars)
                        Console.WriteLine("{0} - {1}", item.Id, item.NameCar);
                }
                else { Console.WriteLine("Not found any car"); 
                }
                           
            }                      
        }
        public  void AddCar(Car car )
        {
            if (car != null)
                using (UnitOfWork db = new UnitOfWork(context))
                {
                    var listCars = db.Cars.GetAll().ToList();
                    db.Cars.Add(car);
                    db.SaveChange();
                    Console.WriteLine("{0} This car was added", car.NameCar);
                }
            else
            {
                Console.WriteLine("Invalid Car");
            }        
        }

        public void RemoveCar(int? Id)
        {
            if (Id != null)
            {
                using (UnitOfWork db = new UnitOfWork(context))
                {
                    var car = db.Cars.Get(i => i.Id == Id);
                    if (car == null)
                    {
                        Console.WriteLine("This is car was deleted");
                    }
                    else
                    {
                        db.Cars.Delete(car);
                        db.SaveChange();
                        Console.WriteLine("You have just removed car {0} - {1}", car.Id, car.NameCar);
                    }
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
                    Console.WriteLine("You have finded car {0}", car.NameCar);
                }    
            }
            }
               else
             {
              Console.WriteLine("Invalid Car");
             }            
        }

        public void UpdateCar(Car car)
        {

            if (car != null)
            {
                using (UnitOfWork db = new UnitOfWork(context))
                {
                   // var car = db.Cars.Get(i => i.Id == car.Id);
                    if (car == null)
                    {
                        Console.WriteLine("You have not finded car ");
                    }
                    else
                    {
                        db.Cars.Udate(car);
                        db.SaveChange();
                        Console.WriteLine("Car was updated {0}", car.NameCar);
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
