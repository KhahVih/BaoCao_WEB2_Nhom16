using CoursesAPI.Data;
using CoursesAPI.Model.DTO;
using CoursesAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        private readonly IStudentRepository _studentRepository;

        public StudentController(AppDbContext dbContext, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _appContext = dbContext;
        }

        [HttpGet("get-all-students")]
        public IActionResult GetAllStudents()
        {
            try
            {
                var allStudents = _studentRepository.GetAllStudent();
                if (allStudents.Count == 0)
                {
                    return NotFound();
                }
                return Ok(allStudents);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-student-by-id/{id}")]
        public IActionResult GetStudentById([FromRoute] int id)
        {
            try
            {
                var studentDTO = _studentRepository.GetStudentById(id);
                if (studentDTO == null)
                {
                    return NotFound();
                }
                return Ok(studentDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-student")]
        public IActionResult AddStudent([FromBody] AddStudentRequestDTO addStudentRequestDTO)
        {
            try
            {
                var studentAdd = _studentRepository.AddStudent(addStudentRequestDTO);
                return Ok(studentAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-student-by-id/{id}")]
        public IActionResult UpdateStudentById(int id, [FromBody] AddStudentRequestDTO studentDTO)
        {
            var existingStudent = _studentRepository.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }
            var updatedStudent = _studentRepository.UpdateStudentById(id, studentDTO);
            return Ok(updatedStudent);
        }

        [HttpDelete("delete-student-by-id/{id}")]
        public IActionResult DeleteStudentById(int id)
        {
            try
            {
                var deletedStudent = _studentRepository.DeleteStudentById(id);
                if (deletedStudent == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
