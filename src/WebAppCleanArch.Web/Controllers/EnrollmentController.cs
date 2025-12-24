using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public EnrollmentController(
            IEnrollmentService enrollmentService,
            IStudentService studentService,
            ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return View(enrollments);
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id.Value);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public async Task<IActionResult> Create(int? courseId)
        {
            await PopulateDropdowns(courseId: courseId);

            if (courseId.HasValue)
            {
                var enrollment = new Enrollment { CourseId = courseId.Value };
                return View(enrollment);
            }

            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,EnrollmentDate,Status,Grade")] Enrollment enrollment)
        {
            // Check duplicate enrollment
            var isEnrolled = await _enrollmentService.IsStudentEnrolledInCourseAsync(enrollment.StudentId, enrollment.CourseId);
            if (isEnrolled)
            {
                ModelState.AddModelError("", "Student sudah terdaftar di course ini!");
            }

            if (ModelState.IsValid)
            {
                var success = await _enrollmentService.CreateEnrollmentAsync(enrollment);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Enrollment berhasil ditambahkan!";
                    return RedirectToAction("Detail", "Course", new { id = enrollment.CourseId });
                }
                
                ModelState.AddModelError("", "Gagal menambahkan enrollment.");
            }

            await PopulateDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id.Value);
            if (enrollment == null)
            {
                return NotFound();
            }

            await PopulateDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,EnrollmentDate,Status,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _enrollmentService.UpdateEnrollmentAsync(enrollment);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Enrollment berhasil diupdate!";
                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError("", "Gagal mengupdate enrollment.");
            }

            await PopulateDropdowns(enrollment.StudentId, enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id.Value);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            var courseId = enrollment?.CourseId;

            var success = await _enrollmentService.DeleteEnrollmentAsync(id);
            
            if (success)
            {
                TempData["SuccessMessage"] = "Enrollment berhasil dihapus!";
                
                if (courseId.HasValue)
                {
                    return RedirectToAction("Detail", "Course", new { id = courseId.Value });
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Gagal menghapus enrollment.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        // Helper Methods
        private async Task PopulateDropdowns(int? selectedStudentId = null, int? selectedCourseId = null)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var courses = await _courseService.GetAllCoursesAsync();

            // Filter students by course if courseId is provided
            if (selectedCourseId.HasValue)
            {
                var enrolledStudentIds = (await _enrollmentService.GetEnrollmentsByCourseIdAsync(selectedCourseId.Value))
                    .Select(e => e.StudentId)
                    .ToList();

                students = students.Where(s => !enrolledStudentIds.Contains(s.Id)).ToList();
            }

            ViewBag.StudentId = new SelectList(students, "Id", "Name", selectedStudentId);
            ViewBag.CourseId = new SelectList(courses, "Id", "CourseName", selectedCourseId);
            ViewBag.StatusList = GetStatusList();
        }

        private List<SelectListItem> GetStatusList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Active", Text = "Active" },
                new SelectListItem { Value = "Completed", Text = "Completed" },
                new SelectListItem { Value = "Dropped", Text = "Dropped" }
            };
        }
    }
}