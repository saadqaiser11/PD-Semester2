using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            student s = new student("Mustafa", 17, 3.5f, 1100, 1100, 200, "Lahore", false);
            float meritPercentage = s.calculateMerit();
            if(s.isEligibleforScholarship(meritPercentage))
            {
                Console.WriteLine("The student is given Scholarship..");
            }
            else
            {
                Console.WriteLine("Not Given Scholarship."); ;
            }

            Console.ReadLine();

        }
    }
}
