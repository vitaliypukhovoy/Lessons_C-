using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Lesson_1._2
{
    class Program
    {
         static void Main(string[] args)
        {
            MyAssembly();
        }

         private static void MyAssembly()
         {

             var directory = Thread.GetDomain().BaseDirectory;
             string dllPath = Path.Combine(directory, "Lesson_11.dll");
             Assembly newAssembly = Assembly.LoadFrom(dllPath);
             //Assembly newAssembly = Assembly.LoadFrom(@"C:\vv\Project\Lessons\Lesson_11\bin\Debug\Lesson_11.dll");

             foreach (var type in newAssembly.GetTypes())
             {
                 Console.WriteLine("Type of loaded class is {0}", type);               
             }
             try
             {
                 // The first  approach
                 //dynamic item = Activator.CreateInstance(newAssembly.GetTypes()[0]);
                 // The second approach
                 // string fullName= newAssembly.GetTypes()[0].FullName;
                 // dynamic item = newAssembly.CreateInstance("fullName");
                 // The third approach
                 dynamic item = newAssembly.CreateInstance("Lesson_11.AddClass");
                 Console.WriteLine("Summa a + b = {0}", item.Add(1, 2));
                 Console.ReadKey();
             }
             catch (ArgumentException)
             {
                 Console.WriteLine("Throw  to reflection load ");
                 Console.ReadKey();
             } 
         }
    }
 }

