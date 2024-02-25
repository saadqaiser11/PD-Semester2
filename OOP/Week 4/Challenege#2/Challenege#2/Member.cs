using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenege_2
{
    internal class Member
    {
        public string nameOfPerson;
        public int MemberId;
        public List <string> booksBought = new List <string> ();
        public int numbookBought;
        public double moneyInBank;
        public double amountSpent;

        public Member(string name, int memberID)
        {
            nameOfPerson = name;
            MemberId = memberID;
            
        }

        public void ModifyName(string newName)
        {
            nameOfPerson = newName;
        }

        public void showName()
        {
            Console.WriteLine("The name of the member is : " + (nameOfPerson));
        }

        public void UpdateBooksBought(List<string> newBooks)
        {
            booksBought = newBooks;
            numbookBought = newBooks.Count;
        }

        public void ModifyBooks(List <string> newBooks)
        {
            booksBought.AddRange(newBooks);
            numbookBought += newBooks.Count;
            amountSpent += 10;
            moneyInBank -= amountSpent;
        }

        public void showBooks()
        {
            for (int i = 0; i < booksBought.Count; i++)
            {
                Console.WriteLine("Name : " + (booksBought[i]));
            }
        }

        public void UpdateAmountSpent(double spentAmount)
        {
            amountSpent += spentAmount;
        }

        public void setAmountSpent(double spentAmount)
        {
            amountSpent = spentAmount;
        }

        public void setMoney(double moneyINBank)
        {
            moneyInBank = moneyINBank;
        }


        public void showMoney()
        {
            Console.WriteLine($"Amount spent: {amountSpent}");
            Console.WriteLine($"Money in bank: {moneyInBank}");
        }










    }
}
