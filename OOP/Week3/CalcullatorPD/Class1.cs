using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcullatorPD
{
    internal class Class1
    {
        public int num1=10;
        public int num2=10;
        public Class1(int num1, int num2)
        {
            this.num1 = num1;
            this.num2 = num2;

        }
        public int sum()
        {
            return num1 + num2;
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
        public int mod()
        {
            return num1 % num2;
        }
    }
}
