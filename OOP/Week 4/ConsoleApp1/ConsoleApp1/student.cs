using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class student
    {
        public string name;
        public int rollNumber;
        public float cgpa;
        public int matricMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostelite;
        public bool isTakingScholarship;

        public student(string name, int rollNumber, float cgpa, int matricMarks, int fscMarks, int ecatMarks, string homeTown, bool isHostelite)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.cgpa = cgpa;
            this.matricMarks = matricMarks;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.homeTown = homeTown;
            this.isHostelite = isHostelite;
        }

        public float calculateMerit()
        {
            float merit = fscMarks * 0.6F + ecatMarks * 0.4F;
            return merit;
        }

        public bool isEligibleforScholarship(float meritPercentage)
        {
            if (meritPercentage > 80 && isHostelite)
            {  
                isTakingScholarship = true;
                return true;
            }

            isTakingScholarship = false;
            return false;
        }


    }
}
