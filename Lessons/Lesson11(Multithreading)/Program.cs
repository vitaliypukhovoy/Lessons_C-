using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11_Multithreading_
{
    class Program
    {
       static void Main(string[] args)
        {
         var rezult=  MyMethod(5, 10);
         Console.WriteLine(rezult.Result);
         Console.ReadKey();
        }
       
        public static  async Task<double> MyMethod( double param1 ,double param2)
        {            
         double result =  await Add(param1,param2);
         return result;
        }

        public static Task<double> Add(double a, double b)
        {           
            return Task<double>.Run(() =>
            {
                return a + b;
            }
          );        
        }
    }
}
