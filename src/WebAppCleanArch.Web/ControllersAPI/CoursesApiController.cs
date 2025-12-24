using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebAppCleanArch.Application.Interfaces;

namespace WebAppCleanArch.Web.Controllers.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CoursesApiController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesApiController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/v1/courses
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllV1()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        // GET: api/v2/courses
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetAllV2()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            var result = courses.Select(c => new
            {
                c.Id,
                c.CourseName,
                c.CourseCode,
                c.Instructor,
                Version = "2.0"
            });
            
            return Ok(result);
        }

        // GET: api/v1/courses/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetByIdV1(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            
            if (course == null)
            {
                return NotFound(new { message = "Course not found" });
            }
            
            return Ok(course);
        }

        // GET: api/v2/courses/5
        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetByIdV2(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            
            if (course == null)
            {
                return NotFound(new { message = "Course not found" });
            }

            var result = new
            {
                course.Id,
                course.CourseName,
                course.CourseCode,
                course.Instructor,
                Version = "2.0"
            };
            
            return Ok(result);
        }
    }
}