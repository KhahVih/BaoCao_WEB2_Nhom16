using System.ComponentModel.DataAnnotations;

namespace CoursesAPI.Model.Domain
{
    public class CoursesStudent
    {
        [Key]
        public int ID { get; set; }
        public int CoursesID { get; set; }
        public Courses? Courses { get; set; }
        public int StudentID { get; set; }
        public Student? Student { get; set; }
    }
}
