using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarySystem
{
    internal class book
    {
        public string title;
        public string author;
        public int pages;
        public List<string> chapters;
        public int bookMark;
        public int price;
        public bool isAvailable;


        public book(string title, string author, int pages, List<string> chapters, int bookMark, int price, bool isAvailable)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.chapters = chapters;
            this.bookMark = bookMark;
            this.price = price;
            this.isAvailable = isAvailable;
        }
        public bool isBookAvailable()
        {
            return isAvailable;
        }

        public string getChapter(int chapterNumber)
        {
            if (chapters[chapterNumber]!=null)
            {
                return chapters[chapterNumber];
            }
            return null;
        }
        public int getBookMark()
        {
            return bookMark;
        }
    }
}
