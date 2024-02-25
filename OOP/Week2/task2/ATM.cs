using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class ATM
    {
        public int balance;
        public List<string> transaction=new List<string>();
        public ATM(int balance)
        {
            this.balance = balance;
        }
        public void depositmoney(int amount)
        {
            balance = balance + amount;
            transaction.Add("Deposited: "+amount);    
        }
        public void withdrawmoney(int amount)
        {
            balance = balance - amount;
            transaction.Add("Withdrawn: " + amount);
        }
        public void checkbalance()
        {
            Console.Write("Your current balance is: {0}\n", balance);
        }
        public void viewtransactionrecords()
        {
            for (int i = 0; i < transaction.Count; i++)
            {
                Console.WriteLine(transaction[i]);
            }
        }
    }
}
