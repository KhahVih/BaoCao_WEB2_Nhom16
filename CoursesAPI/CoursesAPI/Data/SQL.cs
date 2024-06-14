using CoursesAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

    namespace CoursesAPI.Data
    {
        public class SQL
        {
            private readonly ModelBuilder _builder;

            public SQL(ModelBuilder builder)
            {
                _builder = builder;
            }

            public void Seed()
            {
                _builder.Entity<Student>().HasData(
                    new Student
                    {
                        StudentID = 1,
                        StudentName = "Nguyễn ",
                        Email = "nguyenvana@gmail.com",
                        Phones = "0123456789"
                    },
                    new Student
                    {
                        StudentID = 2,
                        StudentName = "Trần Thị B",
                        Email = "tranthib@gmail.com",
                        Phones = "0987654321"
                    }
                );

                _builder.Entity<Courses>().HasData(
                    new Courses
                    {
                        CoursesID = 1,
                        Title = "Introduction to Programming",
                        Description = "Learn the basics of programming with Python.",
                        StartDate = new DateTime(2024, 1, 10),
                        EndDate = new DateTime(2024, 4, 10),
                        Status = "Ongoing"
                    },
                    new Courses
                    {
                        CoursesID = 2,
                        Title = "Web Development",
                        Description = "Learn how to build modern web applications.",
                        StartDate = new DateTime(2024, 2, 15),
                        EndDate = new DateTime(2024, 5, 15),
                        Status = "Upcoming"
                    }
                );
            }
        }
    }


