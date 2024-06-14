using CoursesAPI.Data;
using CoursesAPI.Model.Domain;
using CoursesAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CoursesAPI.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public SQLStudentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentDTO> GetAllStudent()
        {
            var allStudents = _dbContext.Students.Select(student => new StudentDTO()
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Phones = student.Phones,
                Email = student.Email
            }).ToList();

            return allStudents;
        }

        public StudentDTO GetStudentById(int id)
        {
            var student = _dbContext.Students.Where(s => s.StudentID == id);

            var studentWithDomain = student.Select(student => new StudentDTO()
            {
                StudentID = student.StudentID,
                StudentName = student.StudentName,
                Phones = student.Phones,
                Email = student.Email
            }).FirstOrDefault();

            return studentWithDomain;
        }

        public AddStudentRequestDTO AddStudent(AddStudentRequestDTO addStudentRequestDTO)
        {
            var student = new Student
            {
                StudentName = addStudentRequestDTO.StudentName,
                Phones = addStudentRequestDTO.Phones,
                Email = addStudentRequestDTO.Email
            };

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return addStudentRequestDTO;
        }

        public AddStudentRequestDTO? UpdateStudentById(int id, AddStudentRequestDTO studentDTO)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                student.StudentName = studentDTO.StudentName;
                student.Phones = studentDTO.Phones;
                student.Email = studentDTO.Email;

                _dbContext.Students.Update(student);
                _dbContext.SaveChanges();
            }

            return studentDTO;
        }

        public Student? DeleteStudentById(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(s => s.StudentID == id);

            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }

            return student;
        }
    }
}
