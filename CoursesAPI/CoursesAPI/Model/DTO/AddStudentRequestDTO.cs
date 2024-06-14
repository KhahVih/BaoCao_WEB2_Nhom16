namespace CoursesAPI.Model.DTO
{
    public class AddStudentRequestDTO
    {
        public string? StudentName { get; set; } // Tên của học sinh
        public string? Phones { get; set; }
        public string? Email { get; set; }
    }
}
