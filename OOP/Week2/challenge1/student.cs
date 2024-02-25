using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab_Task1
{
    internal class Student
    {
        public string name;
        public float matric_marks;
        public float fsc_marks;
        public float ecat_marks;
        public double aggregate;
        public Student(string name, float matric, float fsc, float ecat, double agg)
        {
            this.name = name;
            this.matric_marks = matric;
            this.fsc_marks = fsc;
            this.ecat_marks = ecat;
            this.aggregate = agg;
        }
    }
}
