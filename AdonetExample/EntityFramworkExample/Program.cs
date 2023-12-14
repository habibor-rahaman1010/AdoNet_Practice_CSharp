using Microsoft.EntityFrameworkCore;
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


            /*//get list of student in dataabse
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
             context.SaveChanges();*/

           /* Course course = new Course
            {
                Title = "Python Programming Language",
                Fees = 5000,
                CourseInstructor = new Instructor
                {
                    Name = "Tamim Sahriar Subeen",
                    Email = "tamimsahriar1010@gmail.com",
                    Phone = "01390284343",
                    Address = "Sidny - Australia"
                },
                Topics = new List<Topic>
                {
                    new Topic{Name = "Variable", Duration = 1},
                    new Topic{Name = "List", Duration = 1},
                    new Topic{Name = "Tuple", Duration = 1}
                }
            };

            context.Courses.Add(course);
            context.SaveChanges();*/

            //find a topics by id and then print that all topics in this code...
            Course? courses =  context.Courses.Include(x => x.Topics).Where(x => x.Id == 2).FirstOrDefault();
            
            if (courses != null)
            {
                courses.Title = "Python Programming";
                foreach (Topic topic in courses.Topics)
                {
                    Console.WriteLine(topic.Name);
                }
            }

            //find a course instractor by id and then that course instractor email update in this code...
            Course? course1 = context.Courses.Include(x => x.CourseInstructor).Where(x => x.Id == 2).FirstOrDefault();
            if (course1 != null)
            {
                //course1.CourseInstructor.Email = "apurbasaha378@gmail.com";
            }

            //find a topics by id and then new topics add in that course...
            Course? course2 = context.Courses.Include(x => x.Topics).Where(x => x.Id == 2).FirstOrDefault();
            if (course2 != null)
            {
                //course2.Topics.Add(new Topic { Name = "Queue data structure", Duration = 1 });
            }

            // find course id and then that id all topics delete this code...
            Course? course3 = context.Courses.Include(x => x.Topics).Where(x => x.Id == 2).FirstOrDefault();
            if (course3 != null)
            {
                List<Topic> topp = course3.Topics.Where(x => x.CourseID > 0).ToList();
                foreach (Topic topic in topp)
                {
                    //course3.Topics.Remove(topic);
                }
            }


            Course course = new Course
            {
                Title = "Python Programming",
                Fees = 6000,
                CourseInstructor = new Instructor
                {
                    Name = "Tamim sahriar Subeen",
                    Email = "tamimsahriarsubeen1010@gmail.com",
                    Phone = "01789348943",
                    Address = "Sidny - Australia"
                },
                Topics = new List<Topic>
                {
                    new Topic{Name = "For Loop", Duration = 1},
                    new Topic{Name = "List Data Structure", Duration = 1},
                    new Topic{Name = "Tuple", Duration = 1}
                },
                Students = new List<CourseStudent>
                {
                    new CourseStudent{Student = new Student{
                        Name = "Habibor Rahaman",
                        Cgpa = 3.78,
                        Email = "habibor.rahaman1010@gmail.com",
                        DateOfBirth = new DateTime(1999, 03, 05),
                        Address = "Mohammodpur - Dhaka"
                    }},
                    new CourseStudent{Student = new Student{
                        Name = "Hasan Ahmed",
                        Cgpa = 3.28,
                        Email = "hasanahmed@gmail.com",
                        DateOfBirth = new DateTime(2000, 03, 05),
                        Address = "Polton - Dhaka"
                    }},
                    new CourseStudent{Student = new Student{
                        Name = "Md Tufayel Islam",
                        Cgpa = 3.98,
                        Email = "mdtufayelislam382@gmail.com",
                        DateOfBirth = new DateTime(1997, 03, 05),
                        Address = "Mirpur - Dhaka"
                    }}
                }
            };

            context.Courses.Add(course);
            context.SaveChanges();
        }
    }
}
