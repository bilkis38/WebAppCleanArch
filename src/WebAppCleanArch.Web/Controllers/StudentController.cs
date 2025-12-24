using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public StudentController(
            IStudentService studentService,
            ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsWithCourseAsync();
            return View(students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentWithDetailsAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public async Task<IActionResult> Create(int? courseId)
        {
            var courses = await _courseService.GetAllCoursesAsync();
            ViewBag.CourseId = new SelectList(courses, "Id", "CourseName", courseId);

            if (courseId.HasValue)
            {
                var student = new Student { CourseId = courseId.Value };
                return View(student);
            }

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PhoneNumber,Address,CourseId")] Student student)
        {
            if (ModelState.IsValid)
            {
                var success = await _studentService.CreateStudentAsync(student);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Student berhasil ditambahkan!";
                    
                    if (student.CourseId.HasValue)
                    {
                        return RedirectToAction("Detail", "Course", new { id = student.CourseId.Value });
                    }

                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError("", "Gagal menambahkan student.");
            }

            var courses = await _courseService.GetAllCoursesAsync();
            ViewBag.CourseId = new SelectList(courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentByIdAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            var courses = await _courseService.GetAllCoursesAsync();
            ViewBag.CourseId = new SelectList(courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,Address,CourseId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _studentService.UpdateStudentAsync(student);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Student berhasil diupdate!";
                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError("", "Gagal mengupdate student.");
            }

            var courses = await _courseService.GetAllCoursesAsync();
            ViewBag.CourseId = new SelectList(courses, "Id", "CourseName", student.CourseId);
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetStudentWithCourseAsync(id.Value);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _studentService.DeleteStudentAsync(id);
            
            if (success)
            {
                TempData["SuccessMessage"] = "Student berhasil dihapus!";
            }
            else
            {
                TempData["ErrorMessage"] = "Gagal menghapus student.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        // POST: Student/RemoveFromCourse/5
        [HttpPost]
        public async Task<IActionResult> RemoveFromCourse(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            var courseId = student.CourseId;
            var success = await _studentService.RemoveStudentFromCourseAsync(id);

            if (success)
            {
                TempData["SuccessMessage"] = "Student berhasil dihapus dari course!";
                
                if (courseId.HasValue)
                {
                    return RedirectToAction("Detail", "Course", new { id = courseId.Value });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Gagal menghapus student dari course.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}