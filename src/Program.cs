using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("The Gradebook");
            // book.GradeAdded += OnGradeAdded;

            // string input;

            Console.WriteLine("Please enter the grade:");

            // input = EnterGrades(book);
        }

        static string EnterGrades(InMemoryBook book)
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
                    char letter = input.ToUpper().ToCharArray()[0];

                    // switch (letter)
                    // {
                    //     case 'A':
                    //         book.AddGrade(letter);
                    //         break;
                    //     case 'B':
                    //         book.AddGrade(letter);
                    //         break;
                    //     case 'C':
                    //         book.AddGrade(letter);
                    //         break;
                    //     case 'D':
                    //         book.AddGrade(letter);
                    //         break;
                    //     case 'Q':
                    //         book.ShowStats();
                    //         break;
                    //     default:
                    //         Console.WriteLine("Invalid input. Try again:");
                    //         break;
                    // }
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
