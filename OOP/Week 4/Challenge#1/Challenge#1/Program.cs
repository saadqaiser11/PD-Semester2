using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            while (true) 
            {
                Console.Clear();
                string choice = menu();

                if(choice == "1")
                {
                    Book b = getInput();
                    Book foundBook = books.Find(book => book.title == b.title);
                    if(foundBook!=null)
                    {
                        Console.WriteLine("The title of the book  is already taken. Book cannnot be added.");
                    }
                    else
                    {
                        books.Add(b);
                    }

                    returnMenu();
                }
                else if(choice == "2")
                {
                    string title = takeTitle();
                    Book foundBook = findBookbyTitle(title, books);
                    if(foundBook!=null)
                    {
                        Console.WriteLine("The Title of the book is : " + foundBook.title);
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
                        Console.WriteLine("The Title of the book is : " + foundBook.title);
                    }
                    else
                    {
                        Console.WriteLine("Book not found...");
                    }

                    returnMenu();

                }
                else if(choice == "4")
                {
                    string title = takeTitle();
                    Book foundBook = findBookbyTitle(title, books);
                    if (foundBook != null)
                    {
                        int quantity = takeQuantity();
                        foundBook.updateCopies(quantity);
                    }
                    else
                    {
                        Console.WriteLine("Book not found...");
                    }
                    returnMenu();
                }
                else if(choice == "5")
                {
                    break;
                }

            }
        }

        static string takeTitle()
        {
            Console.WriteLine("Enter the tile of the book: ");
            return Console.ReadLine();
        }

        static string takeisbn()
        {
            Console.WriteLine("Enter the isbn of the book: ");
            return Console.ReadLine();
        }
        static int takeQuantity()
        {
            Console.WriteLine("Enter the number of books: ");
            return int.Parse(Console.ReadLine());
        }
        static Book findBookbyTitle(string title, List <Book> books)
        {
            Book foundBook = books.Find(book => book.title == title);
            return foundBook;
        }
        static Book findBookbyisbn(string isbn, List<Book> books)
        {
            Book foundBook = books.Find(book => book.isbn == isbn);
            return foundBook;
        }

        static string menu()
        {
            Console.WriteLine("------BOOK MANAGEMENT SYSTEM-------");
            Console.WriteLine("1. ADD BOOK");
            Console.WriteLine("2. SEARCH BOOK BY TITLE");
            Console.WriteLine("3. SEARCH BOOK BY ISBN");
            Console.WriteLine("4. UPDATE THE NUMBER OF BOOKS");
            Console.WriteLine("5. EXIT");
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

            return new Book(title, authors, publisher, isbn, price, stock);

        }
        static string[] takeAuthors(int numAuthors)
        {
            string[] authors = new string[numAuthors];
            for(int i=0; i<numAuthors; i++)
            {
                Console.WriteLine("Enter the " + (i + 1) + " author: ");
                authors[i] = Console.ReadLine();
            }

            return authors;
        }
        static bool isTitleTaken(string title, List <Book> books)
        {
            for(int i=0; i<books.Count; i++)
            {
                if(title == books[i].title)
                {
                    return true;
                }
            }

            return false;
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

        static void returnMenu()
        {
            Console.WriteLine();
            Console.Write("Enter any key...");
            Console.Read();

        }
    }
}
