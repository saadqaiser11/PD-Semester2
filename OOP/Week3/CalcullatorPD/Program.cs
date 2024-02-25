using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcullatorPD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 c = new Class1(1,1);
            //public int num1;
           // public int num2;
            while (true)
            {
                //public int num1;
                //public int num2;
                string option = menu();
                if (option == "1")
                {
                    input(c);
                    


                }
                else if (option == "2")
                {
                    input(c);
                }
                else if (option == "3")
                {
                    Console.WriteLine("The sum is: " + c.sum());
                }
                else if (option == "4")
                {
                    Console.WriteLine("The difference is: " + c.dif());
                }
                else if (option == "5")
                {
                    Console.WriteLine("The multiplication is: " + c.mul());
                }
                else if (option == "6")
                {
                    Console.WriteLine("The division is: " + c.div());
                }
                else if (option == "7")
                {
                    Console.WriteLine("The modulus is: " + c.mod());
                }
                else if (option == "8")
                {
                    break;
                }
            }

        }
       
        static string menu()
        {
            string option="";
            Console.WriteLine("Calculate");
            Console.WriteLine(" 1.Create the a Single Object of Calculator");
            Console.WriteLine(" 2.Change Values of Attributes");
            Console.WriteLine(" 3.Add");
            Console.WriteLine(" 4.Subtract");
            Console.WriteLine(" 5.Multiply");
            Console.WriteLine(" 6.Divide");
            Console.WriteLine(" 7.Modulo");
            Console.WriteLine(" 8.Exit");
            Console.ReadLine();
            return option;
        }   
        /*
        static void obj(ref int num1,ref int num2)
        {
            Class1 c = new Class1(num1, num2);
        }*/
        static void input(Class1 c)
        {
            Console.Write("Enter first number: ");
            c.num1 = int.Parse(Console.ReadLine()) ;
            Console.Write("Enter second number: ");
            c.num2 = int.Parse(Console.ReadLine());
        }
        static void attri(int num1,int num2,Class1 c)
        {
            c.num1 = num1;
            c.num2 = num2;
        }

    }       
}           
            