using System.ComponentModel.DataAnnotations;

namespace CoursesAPI.Model.Domain
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; } // ID của học sinh
        public string? StudentName { get; set; } // Tên của học sinh
        public string? Phones { get; set; }
        public string? Email { get; set; } // Địa chỉ email của học sinh
        public List<CoursesStudent>? CourseStudents { get; set; }
    }
}
