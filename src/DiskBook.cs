using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }

        private List<double> grades;

        public List<double> GetGrades()
        {
            return grades;
        }

        public override void AddGrade(string letter)
        {
        }

        public override void AddGrade(double grade)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Stats GetStats()
        {
            return new Stats();
        }

        public override void ShowStats()
        {
        }
    }
}