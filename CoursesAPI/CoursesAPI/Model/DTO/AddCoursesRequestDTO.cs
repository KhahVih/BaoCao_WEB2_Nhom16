using System.ComponentModel.DataAnnotations;

namespace CoursesAPI.Model.DTO
{
    public class AddCoursesRequestDTO
    {
        [Required]
        [MinLength(2)]
        public string? Title { get; set; } // Tên khóa học
        public string? Description { get; set; } // Mô tả chi tiết về khóa học
        public DateTime StartDate { get; set; } // Ngày bắt đầu khóa học
        public DateTime EndDate { get; set; } // Ngày kết thúc khóa học
        public string? Status { get; set; }
        public List<int>? StudentID { get; set; }
    }
}
