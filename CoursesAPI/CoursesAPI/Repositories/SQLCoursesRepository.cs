using CoursesAPI.Data;
using CoursesAPI.Model.Domain;
using CoursesAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoursesAPI.Repositories
{
    public class SQLCoursesRepository:ICoursesRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLCoursesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CoursesDTO> GetAllCourses()
        {
            var allCourses = _dbContext.Courses.Select(course => new CoursesDTO()
            {
                CoursesID = course.CoursesID,
                Title = course.Title,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Status = course.Status,
                StudentName = course.CoursesStudent.Select(cs => cs.Student.StudentName).ToList()
            }).ToList();

            return allCourses;
        }

        public CoursesDTO GetCoursesById(int id)
        {
            var course = _dbContext.Courses.Where(c => c.CoursesID == id);

            var courseWithDomain = course.Select(course => new CoursesDTO()
            {
                CoursesID = course.CoursesID,
                Title = course.Title,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Status = course.Status,
                StudentName = course.CoursesStudent.Select(cs => cs.Student.StudentName).ToList()
            }).FirstOrDefault();

            return courseWithDomain;
        }

        public AddCoursesRequestDTO AddCourses(AddCoursesRequestDTO addCourseRequestDTO)
        {
            var course = new Courses
            {
                Title = addCourseRequestDTO.Title,
                Description = addCourseRequestDTO.Description,
                StartDate = addCourseRequestDTO.StartDate,
                EndDate = addCourseRequestDTO.EndDate,
                Status = addCourseRequestDTO.Status
            };

            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            foreach (var id in addCourseRequestDTO.StudentID)
            {
                var courseStudent = new CoursesStudent()
                {
                    CoursesID = course.CoursesID,
                    StudentID = id
                };
                _dbContext.CoursesStudents.Add(courseStudent);
                _dbContext.SaveChanges();
            }
            return addCourseRequestDTO;
        }
        public AddCoursesRequestDTO? UpdateCoursesById(int id, AddCoursesRequestDTO courseDTO)
        {
            try
            {
                if (courseDTO == null)
                {
                    throw new ArgumentNullException(nameof(courseDTO), "Course DTO is null");
                }

                // Ghi log thông tin đầu vào
                Console.WriteLine("Start updating course");
                Console.WriteLine($"ID: {id}, Title: {courseDTO.Title}, Description: {courseDTO.Description}");

                // Tìm khóa học theo ID
                var course = _dbContext.Courses.FirstOrDefault(c => c.CoursesID == id);

                if (course == null)
                {
                    throw new KeyNotFoundException($"Course with ID {id} not found");
                }

                // Ghi log thông tin khóa học hiện tại
                Console.WriteLine($"Original Title: {course.Title}, New Title: {courseDTO.Title}");

                // Cập nhật thông tin khóa học
                course.Title = courseDTO.Title ?? course.Title;
                course.Description = courseDTO.Description ?? course.Description;
                course.StartDate = courseDTO.StartDate != default(DateTime) ? courseDTO.StartDate : course.StartDate;
                course.EndDate = courseDTO.EndDate != default(DateTime) ? courseDTO.EndDate : course.EndDate;
                course.Status = courseDTO.Status ?? course.Status;

                _dbContext.Courses.Update(course);
                _dbContext.SaveChanges();

                // Xóa các sinh viên hiện tại khỏi khóa học
                var existingCourseStudents = _dbContext.CoursesStudents.Where(cs => cs.CoursesID == id).ToList();
                _dbContext.CoursesStudents.RemoveRange(existingCourseStudents);
                _dbContext.SaveChanges();

                // Thêm các sinh viên mới vào khóa học
                foreach (var studentId in courseDTO.StudentID)
                {
                    Console.WriteLine($"Adding student ID: {studentId} to course ID: {course.CoursesID}");
                    var courseStudent = new CoursesStudent()
                    {
                        CoursesID = course.CoursesID,
                        StudentID = studentId
                    };
                    _dbContext.CoursesStudents.Add(courseStudent);
                }
                _dbContext.SaveChanges();

                Console.WriteLine("Course updated successfully");
                return courseDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }



        public Courses? DeleteCoursesById(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(c => c.CoursesID == id);

            if (course != null)
            {
                var courseStudents = _dbContext.CoursesStudents.Where(cs => cs.CoursesID == id).ToList();
                _dbContext.CoursesStudents.RemoveRange(courseStudents);
                _dbContext.Courses.Remove(course);
                _dbContext.SaveChanges();
            }

            return course;
        }
    }
}
