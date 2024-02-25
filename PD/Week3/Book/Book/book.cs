using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal class book
    {
        public string title;
        public string author;
        public string PubYear;
        public float price;
        public int quantity;


        public book(string title, string author, string publicationYear, float price, int quantity)
        {
            this.title = title;
            this.author = author;
            PubYear = publicationYear;
            this.price = price;
            this.quantity = quantity;
        }

        public string getTitle()
        {
            return $"Title: {title}";
        }
        public string getAuthor()
        {
            return $"Author: {author}";
        }
        public string getPublicationYear()
        {
            return $"Publication Year: {PubYear}";
        }
        public string getPrice()
        {
            return $"Price: {price}";
        }
        public void sellCopies(int numberOfCopies)
        {
            if(numberOfCopies<=quantity)
            {
                quantity -= numberOfCopies;
            }
            else 
            {
                Console.WriteLine("There are not enough books.");
            }
        }
        public void restock(int additionalCopies)
        {
            quantity += additionalCopies;
        }

        public string bookDetails()
        {
            return $"Title: {title}\nAuthor: {author}\nPublication Year: {PubYear}\nPrice: ${price}\nQuantity in Stock: {quantity}";
        }


    }
}
