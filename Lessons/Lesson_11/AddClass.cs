using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Lesson_1.3")]

namespace Lesson_11
{
    public class AddClass
    {
        public  int Add(int a, int b)
        {
            return a + b;
        }

        internal  int Add2(int a, int b)
        {
            return a + b;
        }
    }
}
