using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class BookFactory
    {
        public static Book CreateGradebook()
        {
            string input;
            string bookName;
            Book Book;

            Console.WriteLine("Enter the gradebook name or 'q' to exit:");
            input = Console.ReadLine();

            if (input.Equals("q"))
                throw new OperationCanceledException("Quitting...");
            else
                bookName = input;

            Console.WriteLine("Select type of gradebook or 'q' to exit:\n1. In memory gradebook\n2. Disk gradebook");
            input = Console.ReadLine();

            if (input.Equals("q"))
                throw new OperationCanceledException("Quitting...");
            else
            {
                switch (input)
                {
                    case "1":
                        Book = new InMemoryBook(bookName);
                        break;
                    case "2":
                        Book = new DiskBook(bookName);
                        break;
                    case "q":
                        throw new OperationCanceledException("Quitting...");
                    default:
                        throw new ArgumentException("Invalid input");
                }

                Book.GradeAdded += OnGradeAdded;
            }

            Console.WriteLine("Please enter the grade or 'q' to exit:");


            while (!input.Equals("q"))
            {
                input = Console.ReadLine();

                if (input.Equals("q"))
                    break;

                try
                {
                    double result;
                    if (double.TryParse(input, out result))
                    {
                        Book.AddGrade(result);
                    }
                    else
                    {
                        Book.AddGrade(input);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Book.ShowStats();

            return Book;
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}