using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public abstract class Book : NamedObject
    {
        protected Book(string name) : base(name)
        {
        }

        // public abstract void AddGrade(double grade);
        // public abstract void ShowStats();
    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        private List<double> grades;

        public List<double> GetGrades()
        {
            return grades;
        }

        public void AddLetterGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public Stats GetStats()
        {
            var result = new Stats();
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            double sum = 0.0;

            foreach (double grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                sum += grade;
            }

            result.Average = sum / grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }

            return result;
        }

        public void ShowStats()
        {
            var result = GetStats();

            Console.WriteLine($"/////////////////////////////////");
            Console.WriteLine($"The average {result.Average:N2}");
            Console.WriteLine($"Lowest grade: {result.Low}");
            Console.WriteLine($"Highest grade: {result.High}");
            Console.WriteLine($"Letter grade: {result.Letter}");

            string showGrades = "The grades are: ";

            foreach (var grade in grades)
            {
                showGrades = String.Concat(showGrades, grade.ToString(), ", ");
            }

            Console.WriteLine($"{showGrades}");
            Console.WriteLine($"/////////////////////////////////");
        }
    }
}