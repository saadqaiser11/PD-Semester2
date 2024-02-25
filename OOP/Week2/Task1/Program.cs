using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.Write("Enter number1: ");
            num1=int.Parse(Console.ReadLine());
            Console.Write("Enter number2: ");
            num2 = int.Parse(Console.ReadLine());
            calculator obj1 = new calculator(num1, num2);
            Console.Write("Enter the operation(+,-,*,/): ");
            char op=char.Parse(Console.ReadLine());
            if (op== '+')
            {
                Console.WriteLine("Sum of {0} and {1} is {2}", num1, num2, obj1.sum());
            }
            else if (op == '-')
            {
                    Console.WriteLine("Sum of {0} and {1} is {2}", num1, num2, obj1.dif());
            }
            else if (op == '*')
            {
                Console.WriteLine("Sum of {0} and {1} is {2}", num1, num2, obj1.mul());
            }
            else if (op == '/')
            {
                Console.WriteLine("Sum of {0} and {1} is {2}", num1, num2, obj1.div());
            }
            Console.ReadKey();
        }
    }
}
