using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List <Member> members = new List<Member>();
            List<double> Mtotal = new List<double>();
            List<double> Sales = new List<double>();

            while (true)
            {

                Console.Clear();
                string choice = menu();
                if (choice == "1")
                {
                    Book b = getInput();
                    Book foundBook = books.Find(book => book.title == b.title);
                    if (foundBook != null)
                    {

                        Console.WriteLine("The title of the book is already taken. Book cannnot be added.");
                    }
                    else
                    {
                        books.Add(b);
                    }

                    returnMenu();

                }
                else if (choice == "2")
                {
                    string title = takeTitle();
                    Book foundBook = findBookbyTitle(title, books);
                    if (foundBook != null)
                    {

                        foundBook.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Book not found...");
                    }

                    returnMenu();

                }

                else if (choice == "3")
                {
                    string isbn = takeisbn();
                    Book foundBook = findBookbyisbn(isbn, books);
                    if (foundBook != null)
                    {
                        foundBook.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Book not found...");
                    }

                    returnMenu();

                }
                else if (choice == "4")
                {
                    string op = takeTitleorIsbn();
                    if (op == "1")
                    {
                        string title = takeTitle();
                        Book foundBook = findBookbyTitle(title, books);
                        if (foundBook != null)
                        {
                            char answer = IncreOrDecre();
                            if (answer == 'i' || answer == 'd')
                            {
                                int quantity = takeQuantity();
                                foundBook.updateCopies(quantity, answer);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect option..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book not found...");
                        }
                    }
                    else if (op == "2")
                    {
                        string isbn = takeisbn();
                        Book foundBook = findBookbyisbn(isbn, books);
                        if (foundBook != null)
                        {

                            char answer = IncreOrDecre();
                            if (answer == 'i' || answer == 'd')
                            {
                                int quantity = takeQuantity();
                                foundBook.updateCopies(quantity, answer);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect option..");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Book not found...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Option..");
                    }

                    returnMenu();
                }

                else if (choice == "5")
                {
                    string op = takeChoiceOfMember();
                    
                    if(op == "1" || op == "2")
                    {
                       bool isMember = isMembert(op);
                        if(isMember)
                        {
                            Member m = getInputforMember();
                            Member FoundbyName = verifyName(members, m);
                            Member FoundbyIsbn = verifyISBN(members, m);
                            if(FoundbyName == null && FoundbyIsbn ==null)
                            {
                                Console.WriteLine("Please pay $10 registration fee.");
                                Mtotal.Add(10);
                                members.Add(m);
                            }
                            else
                            {
                                Console.WriteLine("The name or ISBN of the member is already taken.");
                            }
                            
                        }
                        else
                        {
                            Member m = getInputforNonMember();
                            Member FoundbyName = verifyName(members, m);
                            if (FoundbyName == null)
                            {
                                members.Add(m);
                            }
                            else
                            {
                                Console.WriteLine("The name is already taken.");
                            }
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input ...");
                    }

                    
                    returnMenu();

                }

                else if (choice == "6")
                {
                    string op = takeChoiceOfMember();

                    if(op == "1")
                    {
                        string answer = takeNameorID();
                        if(answer == "1")
                        {
                            string name = takeName();
                            Member found = findMemberByNamw(name, members);
                            if(found != null)
                            {
                                found.DisplayMemberInfo();
                            }
                            else
                            {
                                Console.WriteLine("Member not Found");
                            }

                        }
                        else if(answer == "2")
                        {
                            int id = takeID();
                            Member found = findMemberbyID(id, members);
                            if (found != null)
                            {
                                found.DisplayMemberInfo();
                            }
                            else
                            {
                                Console.WriteLine("Member not Found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("incorrect Option...");

                        }
                    }
                    else if (op == "2")
                    {
                        string name = takeName();
                        Member found = findMemberByNamw(name, members);
                        if (found != null)
                        {
                            found.DisplayNonMember();
                        }
                        else
                        {
                            Console.WriteLine("Person not Found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input...");

                    }

                    returnMenu();
                }

                else if (choice =="7")
                {
                    string op = takeChoiceOfMember();

                    if (op == "1")
                    {
                        string answer = takeNameorID();
                        if (answer == "1")
                        {
                            string name = takeName();
                            Member found = findMemberByNamw(name, members);
                            if (found != null)
                            {
                                string option = ModifyMenuforM();
                                if (option == "1")
                                {
                                    name = takeName();
                                    Member found1 = findMemberByNamw(name, members);
                                    if (found1 == null)
                                    {
                                        found.ModifyName(name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Name is already taken.");
                                    }
                                }
                                else if (option == "2")
                                {
                                   int iD = takeID();
                                   Member foundID = findMemberbyID(iD, members);
                                   if(foundID == null)
                                    {
                                        found.ModifyID(iD);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID is already taken.");
                                    }
                                }
                                else if (option == "3")
                                {
                                    name = takeName();
                                    int iD = takeID();
                                    Member found1 = findMemberByNamw(name, members);
                                    Member foundID = findMemberbyID(iD, members);
                                    if(found1 == null && foundID == null)
                                    {
                                        found.ModifyName(name);
                                        found.ModifyID(iD);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Either the name or the ID is already taken.");
                                    }



                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Option.");

                                }

                            }
                            else
                            {
                                Console.WriteLine("Member not Found");
                            }

                        }
                        else if (answer == "2")
                        {
                            int id = takeID();
                            Member found = findMemberbyID(id, members);
                            if (found != null)
                            {
                                string option = ModifyMenuforM();
                                if (option == "1")
                                {
                                    string name = takeName();
                                    Member found1 = findMemberByNamw(name, members);
                                    if (found1 == null)
                                    {
                                        found.ModifyName(name);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Name is already taken.");
                                    }
                                }
                                else if (option == "2")
                                {
                                    int iD = takeID();
                                    Member foundID = findMemberbyID(iD, members);
                                    if (foundID == null)
                                    {
                                        found.ModifyID(iD);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID is already taken.");
                                    }
                                }
                                else if (option == "3")
                                {
                                    string name = takeName();
                                    int iD = takeID();
                                    Member found1 = findMemberByNamw(name, members);
                                    Member foundID = findMemberbyID(iD, members);
                                    if (found1 == null && foundID == null)
                                    {
                                        found.ModifyName(name);
                                        found.ModifyID(iD);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Either the name or the ID is already taken.");
                                    }



                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Option.");

                                }
                            }
                            else
                            {
                                Console.WriteLine("Member not Found");
                            }
                        }
                        else
                        {
                            Console.WriteLine("incorrect Option...");

                        }
                    }
                    else if (op == "2")
                    {
                        string name = takeName();
                        Member found = findMemberByNamw(name, members);
                        if (found != null)
                        {
                            string option = ModifyMenuForN();
                            if(option == "1")
                            {
                                string name1 = takeName();
                                Member found1 = findMemberByNamw(name1, members);
                                if (found1 == null)
                                {
                                    found.ModifyName(name);
                                }
                                else
                                {
                                    Console.WriteLine("Name is already taken.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Person not Found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Input...");

                    }

                    returnMenu();
                }
                else if (choice == "8")
                {
                    List<Book> boughtBooks = new List<Book>();
                    string name = takeName();
                    int id = takeIDSpec();
                    Member found1 = findMemberByNamw(name, members);
                    Member foundID = findMemberbyID(id, members);
                    if(isMember(found1, foundID))
                    {
                        Console.WriteLine($"| {"Title",-20} | {"Authors",-30} | {"Publisher",-20} | {"ISBN",-15} | {"Price",-10} | {"Stock",-10} | {"Year of Publication",-20} |");
                        for (int i = 0; i<books.Count; i++)
                        {
                            books[i].DisplayInfoTabular();
                        }

                        Console.WriteLine();
                        string title = takeTitle();
                        Book foundBook = findBookbyTitle(title, books);
                        if(foundBook != null)
                        {
                            int quantity = takeQuantity();
                            if(quantity >= 0 && quantity<=foundBook.stock)
                            {
                                if (CheckBalance(quantity, foundBook, found1))
                                {
                                    boughtBooks.Add(foundBook);
                                    foundBook.sellCopies(quantity);
                                    if (id == 0)
                                    {
                                        found1.UpdateAmountSpent(foundBook.amount(quantity));
                                        Sales.Add(foundBook.amount(quantity));
                                    }
                                    else
                                    {
                                        double discount = giveDiscount(foundBook.amount(quantity));
                                        Console.WriteLine("After Discount the price is: $" + discount);
                                        found1.UpdateAmountSpent(discount);
                                        Sales.Add(discount);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Not enough Amount");
                                }
                            }
                            else
                            {
                                Console.WriteLine("NOT possible.");
                            }

                            found1.ModifyBooks(boughtBooks);
                        }
                        else
                        {
                            Console.WriteLine("Book not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Person Not Found");
                    }

                    returnMenu();
                }
                else if (choice =="9")
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("The total sales made by the BookStore is : $" + (TotalSales(Sales)));
                    Console.WriteLine();
                    for(int i=0; i<members.Count; i++)
                    {
                        if (members[i].MemberId != 0)
                        {
                            Console.WriteLine();
                            members[i].DisplayMemberInfo();
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("The total membership fee collected by the BookStore is : $" + (totalFee(Mtotal)));
                    Console.WriteLine();

                    returnMenu();


                }

                else if(choice == "10")
                {
                    break;
                }

            }
        }

        static string menu()
        {
            Console.WriteLine("------BOOK MANAGEMENT SYSTEM-------");
            Console.WriteLine("1. ADD BOOK");
            Console.WriteLine("2. SEARCH BOOK BY TITLE");
            Console.WriteLine("3. SEARCH BOOK BY ISBN");
            Console.WriteLine("4. UPDATE THE STOCK OF BOOKS");
            Console.WriteLine("5. ADD A MEMBER");
            Console.WriteLine("6. SEARCH FOR A MEMBER BY NAME OR ID");
            Console.WriteLine("7. UPDATE MEMBER INFORMATION");
            Console.WriteLine("8. PURCHASE A BOOK");
            Console.WriteLine("9. DISPLAY TOTAL SALES AND MEMBERSHIP STATES");
            Console.WriteLine("10.EXIT");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }

        static Book getInput()
        {
            int numAuthors = 0;


            Console.Write("Enter the title of the Book: ");
            string title = Console.ReadLine();
            Console.Write("Enter the number of authors: ");
            string temp = Console.ReadLine();
            numAuthors = int.Parse(temp);
            numAuthors = validatenumAuthors(numAuthors, temp);
            string[] authors = takeAuthors(numAuthors);
            Console.Write("Enter the publisher of the book: ");
            string publisher = Console.ReadLine();
            Console.Write("Enter the isbn number of the book: ");
            string isbn = Console.ReadLine();
            Console.Write("Enter the price of the book: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Enter the number of copies of the book: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter the Year Of Publication Of THE Book: ");
            int year = int.Parse(Console.ReadLine());

            return new Book(title, authors, publisher, isbn, price, stock, year);

        }

        static int validatenumAuthors(int numAuthors, string temp)
        {
            if ((numAuthors > 4 || numAuthors < 0))
            {

                while ((numAuthors > 4 || numAuthors < 0))
                {
                    Console.WriteLine("The authors must be between 1 and 4...");
                    Console.WriteLine("Enter again: ");
                    temp = Console.ReadLine();
                    numAuthors = validateInt(temp, numAuthors);
                }
            }
            return numAuthors;
        }

        static int validateInt(string temp, int number)
        {
            do
            {

                if (int.TryParse(temp, out number) && number >= 0)
                {
                    return number;
                }
                else
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                    temp = Console.ReadLine();
                }


            } while (!int.TryParse(temp, out number) && number >= 0);

            return number;
        }

        static string[] takeAuthors(int numAuthors)
        {
            string[] authors = new string[numAuthors];
            for (int i = 0; i < numAuthors; i++)
            {
                Console.WriteLine("Enter the " + (i + 1) + " author: ");
                authors[i] = Console.ReadLine();
            }

            return authors;
        }

        static string takeTitle()
        {
            Console.Write("Enter the title of the book: ");
            string title =  Console.ReadLine();
           return title;
        }

        static Book findBookbyTitle(string title, List<Book> books)
        {
            Book foundBook = books.Find(book => book.title == title);
            return foundBook;
        }

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Enter any key...");
            Console.Read();

        }

        static string takeisbn()
        {
            Console.Write("Enter the isbn of the book: ");
            return Console.ReadLine();
        }

        static Book findBookbyisbn(string isbn, List<Book> books)
        {
            Book foundBook = books.Find(book => book.isbn == isbn);
            return foundBook;
        }

        static string takeTitleorIsbn()
        {
            Console.Write("Enter 1 to search with Title or Enter 2 to search with ISBN : ");
            return Console.ReadLine();
        }

        static string takeNameorID()
        {
            Console.Write("Enter 1 to search with Name or Enter 2 to search with ID : ");
            return Console.ReadLine();
        }

        static char IncreOrDecre()
        {
            Console.Write("Enter i to increase or Enter d to decrease: ");
            char answer = char.Parse(Console.ReadLine());
            return answer;
        }

        static int takeQuantity()
        {
            Console.WriteLine("Enter the number of books: ");
            return int.Parse(Console.ReadLine());
        }

        static bool isMembert(string choice)
        {
            if(choice == "1")
            {
                return true;
            }
            
                return false;

        }

        static string takeChoiceOfMember()
        {
            Console.Write("Enter 1 to for a Member or 2 to for a non-Member: ");
            return Console.ReadLine();
        }

        static Member getInputforMember()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            int ID = int.Parse(Console.ReadLine());
            Console.Write("Enter the amount Of Money In Bank: $");
            double money = double.Parse(Console.ReadLine());

            return new Member(name, ID, money);

        }

        static Member getInputforNonMember()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount Of Money In Bank: $");
            double money = double.Parse(Console.ReadLine());
            return new Member(name, 0, money);
        }

        static Member verifyName(List <Member> members, Member m)
        {
            Member FoundMember = members.Find(member => member.nameOfPerson == m.nameOfPerson);
           
            
                return FoundMember;
            
            
        }

        static Member verifyISBN(List<Member> members, Member m)
        {
            Member FoundMember = members.Find(member => member.MemberId == m.MemberId);
            return FoundMember;
        }

        static string takeName()
        {
            Console.Write("Enter name: ");
            return Console.ReadLine();
        }

        static Member findMemberByNamw(string name, List<Member> members)
        {
            Member found = members.Find(member => member.nameOfPerson == name);
            return found;
        }

        static Member findMemberbyID(int ID, List<Member> members)
        {
            Member found = members.Find(member => member.MemberId == ID);
            return found;
        }

        static int takeID()
        {
            Console.Write("Enter ID: ");
            int ID = int.Parse(Console.ReadLine());
            return ID;
        }

        static int takeIDSpec()
        {
            Console.Write("Enter ID (Non-Members enter 0): ");
            int ID = int.Parse(Console.ReadLine());
            return ID;
        }

        static string ModifyMenuforM()
        {
            Console.WriteLine();
            Console.WriteLine("1. Change Name");
            Console.WriteLine("2. Change ID");
            Console.WriteLine("3. Modify Both");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;

        }

        static string ModifyMenuForN()
        {
            Console.WriteLine();
            Console.WriteLine("1. Change Name");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            return choice;

        }

        static bool isMember(Member found1, Member foundID)
        {
            if(found1 != null && foundID != null && found1==foundID)
            {
                return true;
            }

            return false;
        }

        static bool CheckBalance(int quantiy, Book foundbook, Member found1)
        {
            if(foundbook.amount(quantiy)<=(found1.moneyInBank))
            {
                return true;
            }

            return false;
        }

        static double giveDiscount(double amount)
        {
            double amountNew = amount - (amount * 0.5);
            return amountNew;
        }

        static double totalFee(List <double> Mtotal)
        {
            double totalFee = 0;
            for (int i = 0; i < Mtotal.Count; i++)
            {
                totalFee += Mtotal[i];
            }

            return totalFee;
        }

        static double TotalSales(List <double> Sales)
        {
            double total = 0;
            for (int i = 0; i < Sales.Count; i++)
            {
                total += Sales[i];
            }

            return total;
        }



    }
}
