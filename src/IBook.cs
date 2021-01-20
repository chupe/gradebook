using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public interface IBook
    {
        void AddGrade(string letter);
        void AddGrade(double grade);
        void ShowStats();
        Stats GetStats();
        string Name { get; }
        List<double> Grades { get; set;}
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract List<double> Grades { get; set;}

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string letter);

        public Stats GetStats()
        {
            var stats = new Stats(this);
            return stats;
        }

        public void ShowStats()
        {
            GetStats().ShowStats();
        }
    }
}