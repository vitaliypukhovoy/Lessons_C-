using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
   public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        void PrintFirstName();
        void PrintLastName();
        void PrintAge();
        void PrintAll();    
    }
   public interface IStudent
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        void PrintFirstName();
        void PrintLastName();
        void PrintAge();
        void PrintAll();    
    }

   //public interface OutputAll
   //{
   //    void PrintAllPersonStudent();

   //}
   public class Person : IPerson//, OutputAll
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        void IPerson.PrintFirstName()
        {
            Console.WriteLine("FirstName is {0}", FirstName);
        }
        void IPerson.PrintLastName()
        {
            Console.WriteLine("LastName is {0}", LastName);
        }
        void IPerson.PrintAge()
        {
            Console.WriteLine("Age is {0}", Age);
        }
        void IPerson.PrintAll()
        {
            Console.WriteLine("FirstName is {0} LastName is {1} Age is {2} ", FirstName, LastName, Age);
        }
       
    }

   public class Student : Person, IStudent  //, OutputAll
    {
        void IStudent.PrintFirstName()
        {
            Console.WriteLine("FirstName is {0}", FirstName);
        }
        void IStudent.PrintLastName()
        {
            Console.WriteLine("LastName is {0}", LastName);
        }
        void IStudent.PrintAge()
        {
            Console.WriteLine("Age is {0}", Age);
        }
        void IStudent.PrintAll()
        {
            Console.WriteLine("FirstName is {0} LastName is {1} Age is {2} ", FirstName, LastName, Age);
        }

        public  void PrintAllPersonStudent()
        {            
            Console.WriteLine("Output all {0} {1} {2} ",base.FirstName,base.LastName,base.Age);
            Console.WriteLine("Output all {0} {1} {2}", this.FirstName, this.LastName, this.Age);  
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            IPerson person = new Student();
            person.FirstName ="John";
            person.LastName = "Travolta";
            person.Age = 60;
            Console.WriteLine(new string('-',50));
            person.PrintFirstName();
            person.PrintLastName();
            person.PrintAge();
            person.PrintAll();
            

            IStudent student = person as IStudent;
            student.FirstName = "Barak";
            student.LastName = "Obama";
            student.Age = 58;
            Console.WriteLine(new string('-', 50));
            student.PrintFirstName();
            student.PrintLastName();
            student.PrintAge();
            student.PrintAll();
            Console.WriteLine(new string('-', 50));
            Student _student = student as Student;
            _student.PrintAllPersonStudent();
           
            //OutputAll _student = student as OutputAll;
            //_student.PrintAllPersonStudent();
           
            
            
        }
    }
}
