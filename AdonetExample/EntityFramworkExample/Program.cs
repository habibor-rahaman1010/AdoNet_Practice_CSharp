using System;

namespace EntityFramworkExample
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Application Database Stublised.... \n");

            ApplicationDbContext context = new ApplicationDbContext();
            /*context.Students.Add(
                new Student
                {
                    Name = "Habibor Rahaman",
                    Cgpa = 3.92,
                    Email = "habibor.rahaman1010@gmail.com",
                    DateOfBirth = new DateTime(1999, 03, 05),
                    Address = "Dhaka"
                });
            context.Students.Add(
                new Student 
                {
                    Name = "MD Abdullah Rahaman",
                    Cgpa = 3.99,
                    Email = "abdullah.rahaman1010@gmail.com",
                    DateOfBirth = new DateTime(2016, 03, 05),
                    Address = "Dhaka"
                });
            context.Students.Add(
                new Student
                {
                    Name = "MD Mahmudullah Rahaman",
                    Cgpa = 3.98,
                    Email = "mahmudullah.rahaman1010@gmail.com",
                    DateOfBirth = new DateTime(2018, 03, 05),
                    Address = "Dhaka"
                });

            context.Students.Add(
                new Student
                {
                    Name = "MD Abdur Rahaman",
                    Cgpa = 3.98,
                    Email = "abdur.rahaman1010@gmail.com",
                    DateOfBirth = new DateTime(2023, 03, 05),
                    Address = "Dhaka"
                });

            context.Students.Add(
                new Student
                {
                    Name = "Allen Mark",
                    Cgpa = 3.88,
                    Email = "allen.mark0101@gmail.com",
                    DateOfBirth = new DateTime(1989, 03, 05),
                    Address = "Dhaka"
                });*/


           //get list of student in dataabse
           List<Student> allStudent = context.Students.ToList();

            foreach (Student student in allStudent)
            {
                Console.WriteLine($"{student.Email}");
            }
            
            //get student by id...
            Student? singleStudent = context.Students.Where(x => x.Id == 2).FirstOrDefault();
            if (singleStudent != null)
            {
                Console.WriteLine(singleStudent.Name);
            }

            //delete single student in database 
            Student? s1 = context.Students.Where(x => x.Id == 15).FirstOrDefault();
            if (s1 != null)
            {
                context.Students.Remove(s1);
            }

            //delete multiple student in database 
            List<Student> allStudent2 = context.Students.Where(x => x.Id > 15).ToList();
            foreach (Student? student in allStudent2)
            {
                context.Students.Remove(student);
            }
            context.SaveChanges();
        }
    }
}
