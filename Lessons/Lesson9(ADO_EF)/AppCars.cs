using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Lesson9_ADO_EF_
{
    class AppCars
    {

        ContextDB db = new ContextDB();
        public  void AddCar(Car car )
        {         
          db.Cars.Add(car);
          db.SaveChanges();
          var  listCars = db.Cars.ToList();
          foreach (var item in listCars) 
          Console.WriteLine(item.NameCar);                
        }

        public void RemoveCar(int Id)
        {
           var car= db.Cars.Find(Id);
            if (car != null)
            {
                db.Entry(car).State = System.Data.Entity.EntityState.Deleted;
            }

            Console.WriteLine("You have just removed car {0}", car.NameCar);
        }


        public void FindCar(int Id)
        {

            var car= db.Cars.Find(Id);
            if (car != null)
            {
                Console.WriteLine(" You have finded car {0}", car.NameCar);            
            }
        
        
        }
    }
}
