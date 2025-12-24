using Microsoft.AspNetCore.Mvc;
using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }

        // GET: Course/Detail/5
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseWithEnrollmentsAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName,CourseCode,Description,Instructor")] Course course)
        {
            if (ModelState.IsValid)
            {
                var success = await _courseService.CreateCourseAsync(course);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Course berhasil ditambahkan!";
                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError("", "Gagal menambahkan course.");
            }
            
            return View(course);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByIdAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,CourseCode,Description,Instructor")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = await _courseService.UpdateCourseAsync(course);
                
                if (success)
                {
                    TempData["SuccessMessage"] = "Course berhasil diupdate!";
                    return RedirectToAction(nameof(Index));
                }
                
                ModelState.AddModelError("", "Gagal mengupdate course.");
            }

            return View(course);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourseByIdAsync(id.Value);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _courseService.DeleteCourseAsync(id);
            
            if (success)
            {
                TempData["SuccessMessage"] = "Course berhasil dihapus!";
            }
            else
            {
                TempData["ErrorMessage"] = "Gagal menghapus course.";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}