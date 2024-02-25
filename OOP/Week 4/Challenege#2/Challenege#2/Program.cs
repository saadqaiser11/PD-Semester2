using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenege_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <Member> members = new List <Member> ();

            while (true)
            {
                Console.Clear();
                string choice = menu();
                if(choice == "1")
                {
                    Member m = getInput();
                    members.Add (m);
                    returnMenu();
                }
                else if(choice == "2")
                {
                    int id = takeID();
                    Member found = findMember(id, members);
                    double amount = takeAmount();
                    found.setMoney(amount);
                    returnMenu();

                }
                else if (choice == "3")
                {
                    int id = takeID();
                    Member found = findMember(id, members);
                    int number = takeNum();
                    List<string> books = takeBooks(number);
                    found.ModifyBooks(books);
                    returnMenu();

                }
                else if (choice == "4")
                {
                    int id = takeID();
                    Member found = findMember(id, members);
                    found.showMoney();
                    returnMenu();
                }
                else if (choice == "5")
                {
                    break;
                }


            }
        }

        static string menu()
        {
            Console.WriteLine("------BOOK MANAGEMENT SYSTEM-------");
            Console.WriteLine("1. ADD MEMBER");
            Console.WriteLine("2. SET MONEY IN BANK");
            Console.WriteLine("3. BUY BOOKS");
            Console.WriteLine("4. SHOW MONEY DETAILS");
            Console.WriteLine("5. EXIT");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        static Member getInput()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            int ID = int.Parse(Console.ReadLine());

            return new Member(name, ID);

        }

        static int takeID()
        {
            Console.Write("Enter ID: ");
            int ID = int.Parse(Console.ReadLine());
            return ID;
        }

        static double takeAmount()
        {
            Console.Write("Enter the amount: ");
            double money = double.Parse(Console.ReadLine());
            return money;
        }

        static Member findMember(int ID, List <Member> members)
        {
            Member found = members.Find(member => member.MemberId == ID);
            return found;
        }

        static int takeNum()
        {
            Console.Write("Enter the number of books to Buy: ");
            return int.Parse(Console.ReadLine());
        }

        static List <string> takeBooks(int num)
        {
            List <string> books = new List<string>();
            for(int i=0; i<num; i++)
            {
                Console.WriteLine("Enter the book: ");
                books.Add(Console.ReadLine());
            }

            return books;
        }

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Enter any key...");
            Console.Read();

        }
    }
}
