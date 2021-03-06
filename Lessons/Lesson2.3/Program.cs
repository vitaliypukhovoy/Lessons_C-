﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2._3
{
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
            
            List<Student> students = new List<Student>(){
                new Student { FirstName = "Ivanov", LastName = "Ivan",DataBorn=new DateTime(1993,12,14),NumberStyudent=4555555, Course = 5,Average=stud1,Summary=stud1.Average() },
                new Student { FirstName = "Sydorov", LastName = "Sergey",DataBorn=new DateTime(1994,09,12),NumberStyudent=6666666, Course = 5,Average=stud2,Summary=stud2.Average()  },
                new Student { FirstName = "Petrov", LastName = "Aleksander",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud3,Summary=stud3.Average() },
                new Student { FirstName = "Petrenko", LastName = "Pavlo",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud4,Summary=stud4.Average() },
                new Student { FirstName = "Kiriche", LastName = "Denis",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud5,Summary=stud5.Average() },
                new Student { FirstName = "Murashev", LastName = "Nikolay",DataBorn= new DateTime(1991,10,27),NumberStyudent=7777788, Course = 5,Average=stud6,Summary=stud6.Average() }


            };

            Console.WriteLine("|{0,8:G}|{1,10:G}|{2,13:F0}|{3,8:F0}|{4,10:F0}|{5,3:F0}|{6,3:F0}|{7,3:F0}|{8,3:F0}|{9,3:F0}|{10,3:F3}|", "Имя", "Фамилия", "Дата рождения", "Курс", "Номер студ", "1", "2", "3", "4", "5", "Итог");

            foreach (var sdn in students)
            {

                string str = string.Format("|{0,8:G}|{1,10:G}|{2,13:F0}|{3,8:F0}|{4,10:F0}|{5,3:F0}|{6,3:F0}|{7,3:F0}|{8,3:F0}|{9,3:F0}|{10,3:F3}|", sdn.FirstName, sdn.LastName, sdn.DataBorn, sdn.Course, sdn.NumberStyudent, sdn.Average.TryIndex<double>(0), sdn.Average.TryIndex<double>(1), sdn.Average.TryIndex<double>(2), sdn.Average.TryIndex<double>(3), sdn.Average.TryIndex<double>(4), sdn.Summary);
                Console.WriteLine(str);
            }
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