using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Aryan Grade Book");
            book.GradeAdded += OnGradeAdded;

            /* book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(77.5); */
            EnterGrades(book);

            var stats = book.GetStatistics();
            System.Console.WriteLine($"For the book {book.Name}");
            System.Console.WriteLine($"The average grade is {stats.Average:N2}!");
            System.Console.WriteLine($"The highest grade is {stats.High:N2}!");
            System.Console.WriteLine($"The lowest grade is {stats.Low:N2}!");
            System.Console.WriteLine($"The letter grade is {stats.Letter}!");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a Grade or press 'q' to quit");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                // finally
                // {
                //     System.Console.WriteLine("**");   
                // }
            }
        }

        static void OnGradeAdded(object sender,EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}
