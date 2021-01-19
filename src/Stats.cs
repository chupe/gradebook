using System.Collections.Generic;

namespace GradeBook
{
    public class Stats
    {
        public double Average;
        public double Low;
        public double High;
        public char Letter;
        public static List<string> ValidGrades = new List<string>(){ "A", "B", "C", "D" };
    }
}