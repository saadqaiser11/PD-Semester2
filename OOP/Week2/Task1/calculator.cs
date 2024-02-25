using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class calculator
    {
        public int num1;
        public int num2;
        public calculator(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;

        }
        public int sum()
        {
            return num1+num2;
        }
        public int dif()
        {
            return num1 - num2;
        }
        public int mul()
        {
            return num1 * num2;
        }
        public int div()
        {
            return num1 / num2;
        }
    }
}
