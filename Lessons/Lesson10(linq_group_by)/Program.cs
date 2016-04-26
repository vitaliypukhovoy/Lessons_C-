using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_linq_OrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] stud1 = { 5, 5, 5, 5, 5 };
            double[] stud2 = { 4, 3, 4 };
            double[] stud3 = { 4, 2 };
            double[] stud4 = { 5, 5, 5 };
            double[] stud5 = { 4, 5, 4 };
            double[] stud6 = { 5, 5, 5 };

            List<Student> students = new List<Student>(){
                new Student { FirstName = "Ivanov", Groupe=244, LastName = "Ivan",DataBorn=new DateTime(1993,12,14),NumberStyudent=4555555, Course = 5,Average=stud1,Summary=stud1.Average() },
                new Student { FirstName = "Sydorov", Groupe= 244, LastName = "Sergey",DataBorn=new DateTime(1994,09,12),NumberStyudent=6666666, Course = 5,Average=stud2,Summary=stud2.Average()  },
                new Student { FirstName = "Petrov", Groupe= 355, LastName = "Aleksander",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud3,Summary=stud3.Average() },
                new Student { FirstName = "Petrenko",Groupe= 977, LastName = "Pavlo",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 3,Average=stud4,Summary=stud4.Average() },
                new Student { FirstName = "Kirichencko",Groupe=672, LastName = "Denis",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud5,Summary=stud5.Average() },
                new Student { FirstName = "Murashev",Groupe=811, LastName = "Nikolay",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 3,Average=stud6,Summary=stud6.Average() }
            };
            
            var stud = students
                .Where<Student>(i => i.Average.Average() == 5 && i.Course == 3)
                .OrderBy(i=>i.Groupe)
                .OrderBy(i=>i.LastName)
                .Select(i=>i);

           foreach(var item in stud)
           {
           
               Console.WriteLine("{0} {1}", item.Groupe, item.LastName );
           }
           
            Console.ReadKey();
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Groupe { get; set; }
        public DateTime DataBorn { get; set; }
        public int Course { get; set; }
        public int NumberStyudent { get; set; }
        public double[] Average { get; set; }
        public double Summary { get; set; }
    }
}
