using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public override List<double> Grades
        {
            get
            {
                string line;
                List<double> grades = new List<double>();

                using (var file = new System.IO.StreamReader(Name + ".txt"))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        double result;

                        if (double.TryParse(line, out result))
                        {
                            grades.Add(result);
                        }
                        else
                        {
                            var letter = line;
                            switch (letter)
                            {
                                case "A":
                                    grades.Add(90);
                                    break;
                                case "B":
                                    grades.Add(80);
                                    break;
                                case "C":
                                    grades.Add(70);
                                    break;
                                case "D":
                                    grades.Add(60);
                                    break;
                                default:
                                    throw new ArgumentException($"Invalid {nameof(grades)}");
                            }
                        }
                    }
                    file.Close();
                }


                return grades;
            }
            set
            {
                throw new FieldAccessException("Can not set disk grades, try adding instead.");
            }
        }

        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(string grade)
        {
            string letter = grade.Substring(0, 1);
            letter = letter.ToUpper();

            if (Stats.ValidGrades.Contains(letter))
            {
                using (var writer = File.AppendText(Name + ".txt"))
                {
                    writer.WriteLine(letter.ToCharArray());
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                    writer.Close();
                }
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");
        }


        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (var writer = File.AppendText(Name + ".txt"))
                {
                    writer.WriteLine(grade);
                    if (GradeAdded != null)
                    {
                        GradeAdded(this, new EventArgs());
                    }
                    writer.Close();
                }
            }
            else
                throw new ArgumentException($"Invalid {nameof(grade)}");

        }

        public override event GradeAddedDelegate GradeAdded;
    }
}