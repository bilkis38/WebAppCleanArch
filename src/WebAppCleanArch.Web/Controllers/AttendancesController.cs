using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Web.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public AttendancesController(
            IAttendanceService attendanceService,
            IStudentService studentService,
            ICourseService courseService)
        {
            _attendanceService = attendanceService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: Attendances
        public async Task<IActionResult> Index()
        {
            var attendances = await _attendanceService.GetAllAttendances();
            return View(attendances);
        }

        // GET: Attendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _attendanceService.GetAttendanceById(id.Value);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        // POST: Attendances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,CourseId,AttendanceDate,Status,Notes")] Attendance attendance)
        {
            // Validasi tanggal tidak boleh masa lampau
            if (attendance.AttendanceDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AttendanceDate", "Tanggal tidak boleh di masa lampau");
            }

            if (ModelState.IsValid)
            {
                await _attendanceService.AddAttendance(attendance);
                TempData["SuccessMessage"] = "Attendance berhasil ditambahkan!";
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdowns(attendance.StudentId, attendance.CourseId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _attendanceService.GetAttendanceById(id.Value);
            if (attendance == null)
            {
                return NotFound();
            }
            
            await PopulateDropdowns(attendance.StudentId, attendance.CourseId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,CourseId,AttendanceDate,Status,Notes")] Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            // Validasi tanggal tidak boleh masa lampau
            if (attendance.AttendanceDate.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("AttendanceDate", "Tanggal tidak boleh di masa lampau");
            }

            if (ModelState.IsValid)
            {
                await _attendanceService.UpdateAttendance(attendance);
                TempData["SuccessMessage"] = "Attendance berhasil diupdate!";
                return RedirectToAction(nameof(Index));
            }

            await PopulateDropdowns(attendance.StudentId, attendance.CourseId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendance = await _attendanceService.GetAttendanceById(id.Value);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _attendanceService.DeleteAttendance(id);
            TempData["SuccessMessage"] = "Attendance berhasil dihapus!";
            return RedirectToAction(nameof(Index));
        }

        // Helper Methods
        private async Task PopulateDropdowns(int? selectedStudentId = null, int? selectedCourseId = null)
        {
            var students = await _studentService.GetAllStudentsAsync();
            var courses = await _courseService.GetAllCoursesAsync();
            
            ViewBag.Students = new SelectList(students, "Id", "Name", selectedStudentId);
            ViewBag.Courses = new SelectList(courses, "Id", "CourseName", selectedCourseId);
            ViewBag.StatusList = GetStatusList();
        }

        private List<SelectListItem> GetStatusList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Present", Text = "Present" },
                new SelectListItem { Value = "Absent", Text = "Absent" },
                new SelectListItem { Value = "Sick", Text = "Sick" },
                new SelectListItem { Value = "Permission", Text = "Permission" }
            };
        }
    }
}