using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseByIdAsync(int id);
        Task<bool> CreateCourseAsync(Course course);
        Task<bool> UpdateCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
    }
}