using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        Task<Attendance?> GetByIdAsync(int id);
        Task<Attendance> AddAsync(Attendance attendance);
        Task UpdateAsync(Attendance attendance);
        Task DeleteAsync(int id);
        Task<IEnumerable<Attendance>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<Attendance>> GetByCourseIdAsync(int courseId);
        Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}