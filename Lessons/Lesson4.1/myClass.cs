using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4._1
{
    internal class myClass
    {
        public double MethodSum(double a, double b)
        {
            return a + b;
        }

        public double MethodMulty(double a, double b)
        {
            return a * b;
        }

        public double MethodDiv(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Sorry you trried to divide on zero");
            }
            return a / b;
        }

        public double MethodSub(double a, double b)
        {
            return a - b;
        }

    }
}
