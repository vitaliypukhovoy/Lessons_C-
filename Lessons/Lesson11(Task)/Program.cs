using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lesson11_Task_
{
    class Program
    {

        static long a=5, b=6;
        static void Main(string[] args)
        {

            
            

            Task<long> t1 = Task<long>.Run(() =>
            {
                Thread.Sleep(1000);

            }).ContinueWith<long>((t) =>   // Background work
            {
                long c = a * b;
                return c;
            }
            );
            t1.Wait();

              Console.WriteLine("{0}  Thread: {1}", t1.Result, Thread.CurrentThread.ManagedThreadId);
              t1.Wait();



              //Func<long> func = () =>   //This is example how to use Func for Task.Run()
              //{
              //    long c = a * b;
              //    return c;
              //};             
            
             Task<long> t2 = Task<long>.Run(() => {long c = a * b; return c; });
              Thread.Sleep(2000);
              t2.Wait();
              Console.WriteLine("{0}  Thread: {1}", t2.Result, Thread.CurrentThread.ManagedThreadId);  
         


              Task t3 = Task.Factory.StartNew((object obj)=>   
                {
                    Console.WriteLine("{0}  Thread: {1}", obj.ToString(), Thread.CurrentThread.ManagedThreadId);            
                }
                , "Hello word");
              
              Thread.Sleep(3000);
              t3.Wait();

              Console.ReadKey();
           
        }
    }
}
