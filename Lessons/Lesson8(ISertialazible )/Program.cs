using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Globalization;


namespace Lesson8_ISertialazible__
{    
        [Serializable]
        public class Student : ISerializable
    {
            public Student()
            { 
            }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataBorn { get; set; }
        public int Course { get; set; }
        public int NumberStydent { get; set; }
        public double[] Average { get; set; }
        public double Summary { get; set; }

       public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("prop1", FirstName, typeof(string));
            info.AddValue("prop2", LastName, typeof(string));
            info.AddValue("prop3", DataBorn, typeof(DateTime));
            info.AddValue("prop4", Course, typeof(int));
            info.AddValue("prop5", NumberStydent, typeof(int));
            info.AddValue("prop6", Average, typeof(double[]));
            info.AddValue("prop7", Summary, typeof(double));
        }

        public Student(SerializationInfo info, StreamingContext context) 
        {
            FirstName = (string)info.GetValue("prop1", typeof(string));
            LastName = (string)info.GetValue("prop2", typeof(string));
            DataBorn = (DateTime)info.GetValue("prop3", typeof(DateTime));
            Course = (int)info.GetValue("prop4", typeof(int));
            NumberStydent = (int)info.GetValue("prop5", typeof(int));
            Average = (double[])info.GetValue("prop6", typeof(double[]));
            Summary = (double)info.GetValue("prop7", typeof(double));
        }
 
    }
    class Program
    {
        static void Main(string[] args)
        {
            double[] stud1 = { 4, 5, 3, 4, 5 };
            double[] stud2 = { 4, 3, 4 };
            double[] stud3 = { 4, 2 };
            double[] stud4 = { 5, 5, 5 };
            double[] stud5 = { 4, 5, 4 };
            double[] stud6 = { 5, 5, 5 };

            
            Student stud_1 =   new Student { FirstName = "Ivanov", LastName = "Ivan", DataBorn = new DateTime(1993, 12, 14), NumberStydent = 4555555, Course = 5, Average = stud1, Summary = stud1.Average()};
            Student stud_2 =   new Student { FirstName = "Sydorov", LastName = "Sergey",DataBorn=new DateTime(1994,09,12),NumberStydent=6666666, Course = 5,Average=stud2,Summary=stud2.Average()  };
            Student stud_3 =   new Student { FirstName = "Petrov", LastName = "Aleksander",DataBorn= new DateTime(1991,10,27),NumberStydent=7777788, Course = 5,Average=stud3,Summary=stud3.Average() };
            Student stud_4 =   new Student { FirstName = "Petrenko", LastName = "Pavlo",DataBorn= new DateTime(1991,10,27),NumberStydent=7777788, Course = 5,Average=stud4,Summary=stud4.Average() };
            Student stud_5 =   new Student { FirstName = "Kiriche", LastName = "Denis",DataBorn= new DateTime(1991,10,27),NumberStydent=7777788, Course = 5,Average=stud5,Summary=stud5.Average() };
            Student stud_6 =   new Student { FirstName = "Murashev", LastName = "Nikolay",DataBorn= new DateTime(1991,10,27),NumberStydent=7777788, Course = 5,Average=stud6,Summary=stud6.Average() };
       
            Student[] students = { stud_1, stud_2, stud_3, stud_4, stud_5, stud_6};


            //IFormatter formatter = new BinaryFormatter();
            IFormatter formatter = new SoapFormatter();

            string fileName = "mySerizable.data";


            using (FileStream fs = new FileStream(fileName,FileMode.Create))
            {

                formatter.Serialize(fs, students);

            };

            using (FileStream fs = new FileStream(fileName,FileMode.Open))
            {
                Student[] newStudents = (Student[])formatter.Deserialize(fs);

                Console.WriteLine(new string('-', 70));

                 foreach(var item in newStudents)
                 {
                     string databorn = item.DataBorn.Year + "." + item.DataBorn.Month + "." + item.DataBorn.Day;
                     object[] arg = { item.FirstName, item.LastName, databorn, item.Course, item.NumberStydent, item.Average.TryIndex<double>(0), item.Average.TryIndex<double>(1), item.Average.TryIndex<double>(2), item.Average.TryIndex<double>(3), item.Average.TryIndex<double>(4),Math.Round(item.Summary,2) };
                     string str = string.Format(CultureInfo.CurrentCulture, "|{0,8:G}|{1,10:G}|{2,13:F0}|{3,3:F0}|{7,3:F0}|{5,3:F0}|{5,3:F0}|{7,3:F0}|{8,3:F0}|{9,3:F0}|{10,1:F2}|", arg);
                     Console.WriteLine(str);
                 }
                 Console.ReadKey();
            };
            
            
        }
    }
    public static class ArrayExtensions
    {
        public static T TryIndex<T>(this T[] array, int index)
        {
            if (array.Length - 1 >= index)
                return (T)array.GetValue(index);
            else
                return default(T);

        }
    }
}
