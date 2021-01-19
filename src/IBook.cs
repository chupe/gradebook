using System;

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
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract void AddGrade(string letter);

        public virtual Stats GetStats()
        {
            throw new NotImplementedException();
        }

        public abstract void ShowStats();
    }
}