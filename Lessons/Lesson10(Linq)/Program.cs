using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson10_Linq_
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
                new Student { FirstName = "Ivanov", LastName = "Ivan",DataBorn=new DateTime(1993,12,14),NumberStyudent=4555555, Course = 5,Average=stud1,Summary=stud1.Average() },
                new Student { FirstName = "Sydorov", LastName = "Sergey",DataBorn=new DateTime(1994,09,12),NumberStyudent=6666666, Course = 5,Average=stud2,Summary=stud2.Average()  },
                new Student { FirstName = "Petrov", LastName = "Aleksander",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud3,Summary=stud3.Average() },
                new Student { FirstName = "Petrenko", LastName = "Pavlo",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 3,Average=stud4,Summary=stud4.Average() },
                new Student { FirstName = "Kirichencko", LastName = "Denis",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud5,Summary=stud5.Average() },
                new Student { FirstName = "Murashev", LastName = "Nikolay",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 3,Average=stud6,Summary=stud6.Average() }
            };

                 
            int theBestStudents = students.Where<Student>(i => i.Average.Average() == 5 && i.Course==3).Count();
            Console.WriteLine("Count the best students of 3 course  = {0}", theBestStudents);
            Console.ReadKey();
        }        
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataBorn { get; set; }
        public int Course { get; set; }
        public int NumberStyudent { get; set; }
        public double[] Average { get; set; }
        public double Summary { get; set; }
    }

  
         
}
