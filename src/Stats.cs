using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Stats
    {
        public static List<string> ValidGrades = new List<string>() { "A", "B", "C", "D" };
        public List<double> Grades;
        public string Name;

        public Stats(IBook book)
        {
            Name = book.Name;
            Grades = book.Grades;
        }

        public double Low
        {
            get
            {
                double low = 100.0;

                foreach (double grade in Grades)
                {
                    low = Math.Min(grade, low);
                }

                return low;
            }
        }

        public double High
        {
            get
            {
                double high = 0.0;

                foreach (double grade in Grades)
                {
                    high = Math.Max(grade, high);
                }

                return high;
            }
        }

        public char Letter
        {
            get
            {
                char letter;

                switch (Average)
                {
                    case var d when d >= 90.0:
                        letter = 'A';
                        break;
                    case var d when d >= 80.0:
                        letter = 'B';
                        break;
                    case var d when d >= 70.0:
                        letter = 'C';
                        break;
                    case var d when d >= 60.0:
                        letter = 'D';
                        break;
                    default:
                        letter = 'F';
                        break;
                }

                return letter;

            }
        }

        private double Sum
        {
            get
            {
                double sum = 0.0;

                foreach (double grade in Grades)
                {
                    sum += grade;
                }

                return sum;
            }
        }

        public double Average
        {
            get
            {
                return Sum / Grades.Count;
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"---------- {Name} ----------");
            Console.WriteLine($"The average {Average:N2}");
            Console.WriteLine($"Lowest grade: {Low}");
            Console.WriteLine($"Highest grade: {High}");
            Console.WriteLine($"Letter grade: {Letter}");

            string showGrades = "The grades are: ";

            foreach (var grade in Grades)
            {
                showGrades = String.Concat(showGrades, grade.ToString(), ", ");
            }

            Console.WriteLine($"{showGrades}");
            Console.WriteLine($"----------------------------------");
        }
    }
}