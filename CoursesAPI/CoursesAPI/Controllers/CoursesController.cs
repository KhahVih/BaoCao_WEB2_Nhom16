using CoursesAPI.Data;
using Microsoft.Extensions.Logging;
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
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _appContext;
        private readonly ICoursesRepository _courseRepository;

        public CoursesController(AppDbContext dbContext, ICoursesRepository courseRepository)
        {
            _courseRepository = courseRepository;
            _appContext = dbContext;
        }

        [HttpGet("get-all-courses")]
        [Authorize(Roles = "Read, Write")]
        public IActionResult GetAllCourses()
        {
            try
            {
                var allCourses = _courseRepository.GetAllCourses();
                if (allCourses.Count == 0)
                {
                    return NotFound();
                }
                return Ok(allCourses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-course-by-id/{id}")]
       [Authorize(Roles = "Read, Write")]
        public IActionResult GetCourseById([FromRoute] int id)
        {
            try
            {
                var courseDTO = _courseRepository.GetCoursesById(id);
                if (courseDTO == null)
                {
                    return NotFound();
                }
                return Ok(courseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       [HttpPost("add-course")]
       [Authorize(Roles ="Write")]
        public IActionResult AddCourse([FromBody] AddCoursesRequestDTO addCourseRequestDTO)
        {
            try
            {
                var courseAdd = _courseRepository.AddCourses(addCourseRequestDTO);
                return Ok(courseAdd);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-course-by-id/{id}")]
        [Authorize(Roles = "Write")]
        public IActionResult UpdateCourseById(int id, [FromBody] AddCoursesRequestDTO courseDTO)
        {
            var existingCourse = _courseRepository.GetCoursesById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }
            var updatedCourse = _courseRepository.UpdateCoursesById(id, courseDTO);
            return Ok(updatedCourse);
        }

        [HttpDelete("delete-course-by-id/{id}")]
        [Authorize(Roles = "Write")]
        public IActionResult DeleteCourseById(int id)
        {
            try
            {
                var deletedCourse = _courseRepository.DeleteCoursesById(id);
                if (deletedCourse == null)
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
