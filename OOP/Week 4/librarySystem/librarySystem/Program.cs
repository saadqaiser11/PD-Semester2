using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chapters = new List<string>();
            chapters.Add("Introduction");
            chapters.Add("Middle");
            chapters.Add("Outro");

            book b1 = new book("Sidemen", "Jack", 568, chapters, 45, 1200, true);
            book b2 = new book("Second Book", "Harlow", 145, chapters, 21, 1000, false);

            if(b1.isAvailable)
            {
                Console.WriteLine(b1.title + " is Available...");
            }
            else
            {
                Console.WriteLine(b1.title + " is not ..." );

            }

            if (b2.isAvailable)
            {
                Console.WriteLine(b2.title + " is Available...");
            }
            else
            {
                Console.WriteLine(b2.title + " is not ...");

            }
            Console.WriteLine();
            string chapter = b1.getChapter(1);
            if (chapter != null)
            {
                Console.WriteLine(chapter);
            }

            Console.WriteLine() ;
            int mark = b2.bookMark;
            Console.WriteLine(mark) ;
            Console.Read();

        }
    }
}
