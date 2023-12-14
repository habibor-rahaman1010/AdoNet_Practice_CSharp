using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkExample
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;
        public ApplicationDbContext() 
        {
            _connectionString = "Server=HABIBOR-RAHAMAN\\SQLEXPRESS;Database=School;User Id=habibor144369;Password=c++c++c#;Trust Server Certificate=True;";
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudent>().HasKey((x) => new {x.CourseId, x.StudentId});
            modelBuilder.Entity<CourseStudent>().ToTable("CourseStudents");
            modelBuilder.Entity<Instructor>().ToTable("Instructors");
            modelBuilder.Entity<Topic>().ToTable("Topics");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
