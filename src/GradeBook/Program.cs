using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        { 
            IBook book = new DiskBook("Jony's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrade(book);

            var stats = book.GetStatistics();
            
            Console.WriteLine($"For the book name {book.Name}");
            Console.WriteLine($"The Lowest Grade is {stats.Low:N2}");
            Console.WriteLine($"The Highest Grade is {stats.High:N2}");
            Console.WriteLine($"The Average Grade is {stats.Average:N2}");
            Console.WriteLine($"The letter Grade is {stats.Letter}");
            //Console.WriteLine("Showing all greads in bellow: ");
            //for(var index = 0; index < stats.Count; index++)
            //{
            //    Console.WriteLine(stats.Sum);
            //}
        }
        private static void EnterGrade(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
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
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // .. must executable code
                }
            }
        }
        static void OnGradeAdded(object sebder, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}

