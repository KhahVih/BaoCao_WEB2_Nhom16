using Microsoft.EntityFrameworkCore;
using CoursesAPI.Model.Domain;

namespace CoursesAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<CoursesStudent> CoursesStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CoursesStudent>().HasOne(cs => cs.Courses).WithMany(c => c.CoursesStudent).HasForeignKey(cs => cs.CoursesID);

            builder.Entity<CoursesStudent>().HasOne(cs => cs.Student).WithMany(s => s.CourseStudents).HasForeignKey(cs => cs.StudentID);

            new SQL(builder).Seed();
        }
    }
}
