using System;
namespace rajual.CodeLou.ExcerciseProject.Classes{

    public class Student 
    {      
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ClassName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string LastClassCompleted { get; set; }
        public DateTimeOffset LastClassCompletedOn { get; set; }

        public string StudentDisplay => $"({StudentId} | {FirstName} | {LastName} | {ClassName} ) ";

        public string FullName => $"{FirstName} {LastName}"; 

        }

}
