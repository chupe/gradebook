using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
        }

        public override List<double> Grades
        {
            get;
            set;
        }

        public override void AddGrade(string grade)
        {
            string letter = grade.Substring(0, 1);
            letter = letter.ToUpper();

            switch (letter)
            {
                case "A":
                    AddGrade(90);
                    break;
                case "B":
                    AddGrade(80);
                    break;
                case "C":
                    AddGrade(70);
                    break;
                case "D":
                    AddGrade(60);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
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

        public override event GradeAddedDelegate GradeAdded;
    }
}