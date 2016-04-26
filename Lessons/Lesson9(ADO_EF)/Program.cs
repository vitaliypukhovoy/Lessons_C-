using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Configuration;

namespace Lesson9_ADO_EF_
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var obj = new AppCars();
            obj.AddCar(new Car { Id = 1, Color = "White", NameCar = "Porshe", TypeCar = "Jeep" });
            obj.RemoveCar(6);
            obj.FindCar(7);
        }
    }
}
