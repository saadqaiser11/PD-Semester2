using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    internal class Member
    {
        public string nameOfPerson;
        public int MemberId;
        public List<Book> booksBought = new List<Book>();
        public int numbookBought;
        public double moneyInBank;
        public double amountSpent;
        

        public Member(string name, int memberID, double moneyinBank)
        {
            nameOfPerson = name;
            MemberId = memberID;
            if (memberID != 0)
            {
                moneyInBank = moneyinBank - 10;
                
            }
            else
            {
                moneyInBank = moneyinBank;
            }
            

        }
        

        public void ModifyName(string newName)
        {
            nameOfPerson = newName;
        }

        public void ModifyID(int ID)
        {
            MemberId = ID;
        }

        public void showName()
        {
            Console.WriteLine("The name of the member is : " + (nameOfPerson));
        }

        
        public void ModifyBooks(List<Book> newBooks)
        {
            booksBought.AddRange(newBooks);
            numbookBought += newBooks.Count;
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
            moneyInBank -= amountSpent;
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

        public void DisplayMemberInfo()
        {
            Console.WriteLine("Name of Person: " + nameOfPerson);
            Console.WriteLine("Member ID: " + MemberId);
            Console.WriteLine("Number of Books Bought: " + numbookBought);
            Console.WriteLine("Money in Bank: " + moneyInBank);
            Console.WriteLine("Amount Spent: " + amountSpent);
        }

        public void DisplayNonMember()
        {
            Console.WriteLine("Name of Person: " + nameOfPerson);
            Console.WriteLine("Number of Books Bought: " + numbookBought);
            Console.WriteLine("Money in Bank: " + moneyInBank);
            Console.WriteLine("Amount Spent: " + amountSpent);
        }

        
    }
}
