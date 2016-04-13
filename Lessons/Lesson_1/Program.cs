using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_11;


namespace Lesson2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyAssembly();
        }

        private static void MyAssembly()
        {
            AddClass obj = new AddClass();
            int sum = obj.Add(1, 2);
            Console.WriteLine("sum a + b = {0}", sum);
            Console.ReadKey();
        
        }
    }
}
