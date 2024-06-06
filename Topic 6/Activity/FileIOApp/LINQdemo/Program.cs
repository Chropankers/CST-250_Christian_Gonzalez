using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part 1: Print a list of only the B students (80% to 89%) in ascending order
            var scores = new[] { 50, 66, 90, 81, 77, 45, 0, 100, 99, 72, 87, 85, 81, 80, 77, 74, 95, 97 };

            // Print the scores
            Console.WriteLine("All Scores:");
            foreach (var individualScore in scores)
            {
                Console.WriteLine($"Score: {individualScore}");
            }

            // Pause to see the output before closing
            Console.ReadLine();

            // Use LINQ to filter and sort the B students
            var bStudents = scores.Where(score => score >= 80 && score <= 89)
                                  .OrderBy(score => score);

            Console.WriteLine("B Students (80-89) in ascending order:");
            foreach (var individualScore in bStudents)
            {
                Console.WriteLine($"B Score: {individualScore}");
            }

            // Pause to see the output before closing
            Console.ReadLine();

            // Part 2: Create an arraylist of students and demonstrate the use of LINQ
            List<Student> students = new List<Student>
            {
                new Student { Name = "John", Age = 20, Grade = 85 },
                new Student { Name = "Jane", Age = 22, Grade = 90 },
                new Student { Name = "Mike", Age = 21, Grade = 78 },
                new Student { Name = "Alice", Age = 23, Grade = 88 },
                new Student { Name = "Bob", Age = 19, Grade = 82 }
            };

            // Print all students
            Console.WriteLine("All Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} (Age: {student.Age}) - Grade: {student.Grade}");
            }

            // Pause to see the output before closing
            Console.ReadLine();

            // Use LINQ to filter and sort students with grades between 80 and 89
            var filteredStudents = students.Where(s => s.Grade >= 80 && s.Grade <= 89)
                                           .OrderBy(s => s.Grade);

            Console.WriteLine("Filtered students with grades between 80 and 89:");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"{student.Name} (Age: {student.Age}) - Grade: {student.Grade}");
            }

            // Pause to see the output before closing
            Console.ReadLine();
        }
    }
}