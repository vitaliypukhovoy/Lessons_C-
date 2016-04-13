using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_11;

namespace lesson_1._3
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
            int sum = obj.Add2(1, 2);

            Console.WriteLine("This is Example how to use freadly assembly");
            Console.WriteLine("sum a + b = {0}", sum);
            Console.ReadKey();

        }
    }
}
