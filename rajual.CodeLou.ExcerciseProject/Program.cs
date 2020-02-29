using System;
using rajual.CodeLou.ExcerciseProject.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace rajual.CodeLou.ExcerciseProject
{
    class Program
    {
        const string jsonfile = @"students.json"; 
        static string theDirectory = AppDomain.CurrentDomain.BaseDirectory;
        static string _studentRepositoryPath = $"{jsonfile}";
        static List<Student> studentsList = File.Exists(_studentRepositoryPath) ? Read() : new List<Student>(); 
        public static async Task Save()  {
            using (var file = File.CreateText(_studentRepositoryPath))
        {
            await file.WriteAsync(JsonSerializer.Serialize(studentsList));
        }
        }
            static List<Student> Read() {
            return JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(_studentRepositoryPath));
        }
        //static List<Student> studentsList =  new List<Student>();
        static void Main(string[] args)
        {
            var inputtingStudent = true;

            while (inputtingStudent)
            {
                DisplayMenu();
                var option = Console.ReadLine();

                switch (int.Parse(option))
                {
                    case 1:
                        InputStudent();
                        break;
                    case 2:
                        DisplayStudents();

                        break;
                    case 3:
                        SearchStudents();
                        break;
                    case 4:
                        inputtingStudent = false;
                        break;
                }
            }
         }

        private static void DisplayMenu()
        {
            Console.WriteLine("Select from the following operations:");
            Console.WriteLine("1: Enter new student");
            Console.WriteLine("2: List all students");
            Console.WriteLine("3: Search for student by name");
            Console.WriteLine("4: Exit");
        }
        private static void DisplayStudents() => DisplayStudents(studentsList);
        private static void DisplayStudents(IEnumerable<Student> students)
        {
            if (students.Any()) 
            {
                Console.WriteLine($"Student Id | Name |  Class ");
                studentsList.ForEach(x =>
                {
                    Console.WriteLine(x.StudentDisplay);
                });
            }
            else 
            {
                System.Console.WriteLine("No students found.");
            }
        }
        private static void SearchStudents()
            {
                Console.WriteLine("Search for Student:");
                var searchString = Console.ReadLine();
                var students = studentsList.Where(x => x.FullName.Contains(searchString)).ToList();
                DisplayStudents(students);
            }


        private static void InputStudent()              
            {
            var student = new Student();
            while (true) 
            {
                Console.WriteLine("Enter Student Id");
                var studentIdSuccessful = int.TryParse(Console.ReadLine(), out var studentId);
                if (studentIdSuccessful) 
                {
                    student.StudentId = studentId;    
                    break;
                }
            }
            Console.WriteLine("Enter First Name");
            var studentFirstName = Console.ReadLine();
            student.FirstName = studentFirstName;
            Console.WriteLine("Enter Last Name");
            var studentLastName = Console.ReadLine();
            student.LastName = studentLastName;
            Console.WriteLine("Enter Class Name");
            var className = Console.ReadLine();
            student.ClassName = className;
            Console.WriteLine("Enter Last Class Completed");
            var lastClass = Console.ReadLine();
            student.LastClassCompleted = lastClass;
            while (true) {
                Console.WriteLine("Enter Last Class Completed Date in format MM/dd/YYYY");
                var lastCompletedOnSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var lastClassCompletedOn);
                if (lastCompletedOnSuccessful) {
                    student.LastClassCompletedOn = lastClassCompletedOn;
                    break;
                }
            } 
            while (true) {
                Console.WriteLine("Enter Start Date in format MM/dd/YYYY");
                var startDateSuccessful = DateTimeOffset.TryParse(Console.ReadLine(), out var startDate);
                if (startDateSuccessful) {
                    student.StartDate = startDate;
                    break;
                }
            }
            studentsList.Add(student);
                    Save();
        }            
    }
}
