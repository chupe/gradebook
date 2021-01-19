using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            // var book = new InMemoryBook("The Memory Book");
            // book.GradeAdded += OnGradeAdded;

            var diskBook = new DiskBook("The Disk Book");
            diskBook.GradeAdded += OnGradeAdded;

            string input;

            Console.WriteLine("Please enter the grade:");

            input = EnterGrades(diskBook);
        }

        static string EnterGrades(IBook book)
        {
            string input;
            do
            {
                input = Console.ReadLine();
                Console.WriteLine($"The input is: {input}");

                double result;

                if (double.TryParse(input, out result))
                {
                    try
                    {
                        book.AddGrade(result);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                }
                else if (input.Length == 1)
                {
                    string letter = input.Substring(0, 1);
                    letter = letter.ToUpper();

                    switch (letter)
                    {
                        case var grade when Stats.ValidGrades.Contains(grade):
                            book.AddGrade(letter);
                            break;
                        case "Q":
                            book.ShowStats();
                            break;
                        default:
                            Console.WriteLine("Invalid input. Try again:");
                            break;
                    }
                }

            } while (!input.Equals("q"));

            return input;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}
