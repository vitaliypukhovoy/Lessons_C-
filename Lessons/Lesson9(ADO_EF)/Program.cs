using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;
using Lesson9_dll_ADO_EF_;

namespace Lesson9_ADO_EF_
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextDB db = new ContextDB();
            var obj = new AppCars(db);                               
           
            obj.UpdateCar(new Car { Id = 3, Color = "XXXXXX", NameCar = "XXXXXX", TypeCar = "XXXXXX" });
            obj.FindCar(1);
            obj.RemoveCar(2);           
            obj.AddCar(new Car { Color = "White", NameCar = "Porshe", TypeCar = "Jeep" });
            obj.GetCar();
          

        }
    }
}
