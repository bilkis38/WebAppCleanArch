using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using WebAppCleanArch.Application.Interfaces;

namespace WebAppCleanArch.Web.Controllers.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class StudentsApiController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsApiController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/v1/students
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetAllV1()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/v2/students
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetAllV2()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var result = students.Select(s => new
            {
                s.Id,
                s.Name,
                s.Email,
                Version = "2.0"
            });
            
            return Ok(result);
        }

        // GET: api/v1/students/5
        [HttpGet("{id}")]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetByIdV1(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }
            
            return Ok(student);
        }

        // GET: api/v2/students/5
        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetByIdV2(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            var result = new
            {
                student.Id,
                student.Name,
                student.Email,
                Version = "2.0"
            };
            
            return Ok(result);
        }
    }
}