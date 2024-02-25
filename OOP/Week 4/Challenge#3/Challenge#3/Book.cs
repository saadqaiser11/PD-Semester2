using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    internal class Book
    {
        public string title;
        public string[] authors = new string[4];
        public string publisher;
        public string isbn;
        public double price;
        public int stock;
        public int numAuthors;
        public int yearOfPublication;
        

        // Constructor
        public Book(string title, string[] authors, string publisher, string isbn, double price, int stock, int yearOfPublication)
        {
            this.title = title;
            this.authors = authors;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
            this.numAuthors = authors.Length;
            this.yearOfPublication = yearOfPublication;
        }

        public void showTitle()
        {
            Console.WriteLine("The title of the book is : " + title);
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public bool isTitle(string title)
        {
            if (this.title == title)
            {
                return true;
            }
            return false;
        }

        public void showCopies()
        {
            Console.WriteLine("The number of copies of the book is : " + stock);
        }

        public void setNumCopies(int quantity)
        {
            stock = quantity;
        }

        public void updateCopies(int num, char answer)
        {
            if (answer == 'i')
            {
                stock += num;
            }
            else if (answer == 'd')
            {
                stock -= num;
            }

        }
        public void sellCopies(int num)
        {
            stock -= num;
            
        }

        public int getStock()
        {
            return stock;
        }

        public void setPublisher(string publisher)
        {
            this.publisher = publisher;
        }

        public string getPublisher()
        {
            return this.publisher;
        }

        public void setISBN(string isbn)
        {
            this.isbn = isbn;
        }

        public string getISBN()
        {
            return isbn;
        }

        public void setprice(double price)
        {
            this.price = price;
        }

        public double getPrice()
        {
            return price;
        }

        public void getAuthors()
        {
            Console.WriteLine("The authors of the book are: ");
            for (int i = 0; i < authors.Length; i++)
            {
                Console.WriteLine(authors[i]);
            }
        }

        public bool isLessThanFour()
        {
            if (numAuthors < 4)
            {
                return true;
            }
            return false;
        }

        public void setAuthors(string[] authors)
        {
            this.authors = authors;
        }

        public double amount(int quantity)
        {
            return quantity * this.price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.Write("Authors: ");
            for (int i = 0; i < authors.Length; i++)
            {
                if (i != authors.Length - 1)
                {
                    Console.Write(authors[i] + ", ");
                }
                else
                {
                    Console.Write(authors[i]);
                }
            }
                Console.WriteLine();
                Console.WriteLine("Publisher: " + publisher);
                Console.WriteLine("ISBN: " + isbn);
                Console.WriteLine("Price: " + price);
                Console.WriteLine("Stock: " + stock);
                Console.WriteLine("Year of Publication: " + yearOfPublication);
            
        }

        public void DisplayInfoTabular()
        {
            
            Console.WriteLine($"| {title,-20} | {string.Join(", ", authors),-30} | {publisher,-20} | {isbn,-15} | {price,-10:F2} | {stock,-10} | {yearOfPublication,-20} |");
        }

        

    }
}
