using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;

namespace Lesson2._1
{
    class Program
    {
        static void Main(string[] args)
        {         
            var str_file = new StringBuilder();
            var directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = Path.Combine(directory, "Text.txt");
            using (StreamReader sr = File.OpenText(path))
            {
                string s="";
                while ((s = sr.ReadLine()) != null)
                {
                    str_file.Append(s);
                }                         
            }             
                      var sb = new StringBuilder();
                      foreach (var ch in str_file.ToString())
                      { 
                          if (ch.Equals('n'))
                              continue;
                          if (ch.Equals(','))
                          {
                              sb.Append(String.Concat(ch, '-'));
                              continue;
                          }
                          sb.Append(ch);
                      }
                 
                sb.Append('\n');
                sb.AppendLine("Hello");    
               
               var new_str =  Method(sb.ToString());
               var new_str2 = Method3(sb.ToString());


               string[] lines = new_str.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
               //var refferHello = lines[lines.Length - 1];
               var referHello=  lines.Where(i=>i.Contains("Hello")).Select(i=>i);
               foreach (var item in referHello)
               {
                   Console.BackgroundColor = ConsoleColor.DarkMagenta;
                   Console.WriteLine(" The refer to 'Hello' string is -{0} ", item);
                   Console.BackgroundColor = ConsoleColor.Black;
               }

               Console.BackgroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine("Formatted text");
               Console.BackgroundColor = ConsoleColor.Black;
               Console.WriteLine(new_str);
             
               
               Console.WriteLine(new string('-',50));
               Console.BackgroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine("Usual text");
               Console.BackgroundColor = ConsoleColor.Black;
               Console.WriteLine(new_str2);
               Console.ReadKey();
        }        
        public static string Method(string str2 ) //formatted text
        {
          var sb1 = new StringBuilder();
          int space = 0;

          foreach (var ch1 in str2)
          {
              
              if (ch1.Equals(' '))
            {
                space = sb1.Length;
            }
                  
               sb1.Append(ch1);

               if (sb1.Length % 50 == 0 && ch1.Equals(' '))
               {
                   sb1.Append('\n');
               }              
              int summ =  (sb1.Length - space);
              if (sb1.Length % 50 == 0 && sb1.Length !=1  )
            {
                    sb1.Insert(space, ".", summ-1);              
                    sb1.Insert(space + summ, '\n');
            }
         }

            return sb1.ToString();
        }
        public static string Method3(string str2) //Usual text
        {
            var sb1 = new StringBuilder();
            foreach (var ch1 in str2)
            {

                sb1.Append(ch1);

                if (sb1.Length % 50 == 0 && ch1.Equals(' '))
                {
                    sb1.Append('\n');
                }            
                if (sb1.Length % 50 == 0 && sb1.Length != 1)
                {
                     sb1.Append('\n');

                }
            }
            return sb1.ToString();
        }
    }
}
