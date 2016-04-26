using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace Lesson11_parallel_
{
    class Program
    {
        static void Main(string[] args){

            Multiplication(2);
            Multiplication(4);
            Multiplication(7);

        }


        public static void Multiplication(int factor)
        {            
            List<int> array = new List<int>() { 1, 2, 3 };
            var rangePartitioner = Partitioner.Create(0, array.ToArray().Length);

            Parallel.ForEach(rangePartitioner, range =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    array[i] = array[i] * factor;
                    Console.WriteLine(array[i]);
                }
            });
        
        }           
      }
    }

