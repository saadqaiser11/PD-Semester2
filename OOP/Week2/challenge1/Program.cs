
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Week2Lab_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Student[] students = new Student[100];
            while (true)
            {
                Console.WriteLine("\t\t\t STUDENT MANAGEMENT SYSTEM");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Calculate Aggregate");
                Console.WriteLine("4. Top Students");
                Console.WriteLine("5. Exit");
                Console.Write("Enter Option Number: ");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tAdd Student\n\n");
                    students[count] = addstudent();
                    count++;
                }
                else if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tShow Students\n\n");
                    showstudents(students, count);
                }
                else if (option == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tCalculate Aggregate\n\n");
                    
                }
                else if (option == 4)
                {
                    Console.Clear();
                    topstudents(students, ref count);
                }
                else if (option == 5)
                {
                    Console.Clear();
                    break;
                }
                Console.WriteLine("\n\nPress any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static Student addstudent()
        {
            string name;
            float matric, fsc, ecat;
            float agg = 0F;
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            Console.Write("Enter Matric Marks: ");
            matric = float.Parse(Console.ReadLine());
            Console.Write("Enter Inter Marks: ");
            fsc = float.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            ecat = float.Parse(Console.ReadLine());
            Student s1 = new Student(name, matric, fsc, ecat, agg);
            return s1;
        }
        static void showstudents(Student[] students, int count)
        {
            if (count > 0)
            {
                Console.WriteLine("Student Name \t\t Matric Marks \t\t FSC Marks \t\t ECAT Marks");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0} \t\t \t  {1} \t\t\t {2} \t\t\t {3}", students[i].name, students[i].matric_marks, students[i].fsc_marks, students[i].ecat_marks);
                }
            }
            else
                Console.WriteLine("No Studens Available.");
        }
       
        static void topstudents(Student[] students, ref int count)
        {

            calculateaggregate(students, count, 0);
            if (count <= 3)
            {
                Console.WriteLine("\t\t\t\t TOP 3 Students\n");
                Console.WriteLine("Student Name \t\t Aggregate");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0} \t\t \t {1}", students[i].name, students[i].aggregate);
                }
            }
            else if (count > 3)
            {
                double[] aggreg = new double[count];
                for (int x = 0; x < count; x++)
                {
                    aggreg[x] = students[x].aggregate;
                }
                sorttopstudents(aggreg);
                Console.WriteLine("\t\t\t\t TOP 3 Students\n");
                Console.WriteLine("Student Name \t\t Aggregate");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        if (students[j].aggregate == aggreg[i])
                            Console.WriteLine("{0} \t\t \t {1}", students[j].name, students[j].aggregate);
                    }
                }
            }
        }
        static void calculateaggregate(Student[] students, int count, int id)
        {
            for (int i = 0; i < count; i++)
            {
                students[i].aggregate = (((students[i].matric_marks * 100) / 1100) * 0.1) + (((students[i].fsc_marks * 100) / 1100) * 0.4) + (((students[i].ecat_marks * 100) / 400) * 0.5);
            }
            if (id == 1)
            {
                Console.WriteLine("Student Name \t\t Aggregate");
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0} \t\t\t {1}", students[i].name, students[i].aggregate);
                }
            }
        }
        static void sorttopstudents(double[] aggreg)
        {
            int n = aggreg.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (aggreg[j] < aggreg[j + 1])
                    {
                        double temp = aggreg[j];
                        aggreg[j] = aggreg[j + 1];
                        aggreg[j + 1] = temp;
                    }
                }
            }
        }
    }
}

