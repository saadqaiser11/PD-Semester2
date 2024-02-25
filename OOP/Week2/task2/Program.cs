using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM obj = new ATM(100);
            obj.checkbalance();
            obj.depositmoney(500);
            obj.withdrawmoney(200);
            obj.checkbalance();
            obj.depositmoney(700);
            obj.withdrawmoney(400);
            obj.checkbalance();
            obj.viewtransactionrecords();
            Console.ReadKey();
        }
    }
}
