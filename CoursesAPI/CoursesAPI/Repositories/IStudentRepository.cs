using CoursesAPI.Model.Domain;
using CoursesAPI.Model.DTO;

namespace CoursesAPI.Repositories
{
    public interface IStudentRepository
    {
        List<StudentDTO> GetAllStudent();
        StudentDTO GetStudentById(int id);
        AddStudentRequestDTO AddStudent(AddStudentRequestDTO addStaffRequestDTO);
        AddStudentRequestDTO? UpdateStudentById(int id, AddStudentRequestDTO studentDTO);
        Student? DeleteStudentById(int id);
    }
}

