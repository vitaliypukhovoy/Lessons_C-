using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Lesson11
{
    class Program
    {

        public delegate int myDeledate(int a, int b);
        static void Main(string[] args)
        {     
        var del =  new  Func<double,double,double>((a,b)=>{ return (a+b); });
       //  myDeledate del = MutihtreadingClass.ThreadFunction;
        IAsyncResult asyncResult = del.BeginInvoke(1, 10, new AsyncCallback(MyCallback), null );
                
        Thread.Sleep(4000);
        Console.WriteLine("Method Add  have  just finished ");           
        }

        private  static void MyCallback(IAsyncResult ar)
        {
           AsyncResult result = (AsyncResult)ar;
           var caller = (Func<double,double,double>)result.AsyncDelegate;
           string formatString = (string)ar.AsyncState;
           double returnValue = caller.EndInvoke(ar);  
            
            Console.WriteLine("a + b = {0}" ,  returnValue);                
        }                              
    }


    class MutihtreadingClass
    {
        public static int ThreadFunction(int a, int b)
        {
            return  a + b;            
        }
    }
}
