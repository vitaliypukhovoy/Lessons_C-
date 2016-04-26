using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lesson9_ADO_EF_
{
    public class Initializer : CreateDatabaseIfNotExists<ContextDB>
    {
        protected override void Seed(ContextDB context)
        {

            var worlds = new List<Car>{
            
             new Car {Id=1,Color="White",NameCar="KIA",TypeCar="Sedan"},
             new Car {Id=2,Color="Red",NameCar="Subaru",TypeCar="Sedan"},
             new Car {Id=3,Color="Blou",NameCar="Audi",TypeCar="Jeep"},
             new Car {Id=4,Color="Black",NameCar="Mersedes",TypeCar="Sedan"},
             new Car {Id=5,Color="Yellow",NameCar="Porshe",TypeCar="Jeep"},
             new Car {Id=1,Color="Green",NameCar="Skoda",TypeCar="Sedan"},                                              
            };
            worlds.ForEach(s => context.Cars.Add(s));
        }

    }
}
