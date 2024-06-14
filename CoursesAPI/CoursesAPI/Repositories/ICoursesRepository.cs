using CoursesAPI.Model.Domain;
using CoursesAPI.Model.DTO;

namespace CoursesAPI.Repositories
{
    public interface ICoursesRepository
    {

        List<CoursesDTO> GetAllCourses();
        CoursesDTO GetCoursesById(int id);
        AddCoursesRequestDTO AddCourses(AddCoursesRequestDTO addCoursesRequestDTO);
        AddCoursesRequestDTO? UpdateCoursesById(int id, AddCoursesRequestDTO jobCourses);
        Courses? DeleteCoursesById(int id);
    }
}

