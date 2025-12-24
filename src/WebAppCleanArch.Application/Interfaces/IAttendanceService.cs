using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAttendances();
        Task<Attendance?> GetAttendanceById(int id);
        Task AddAttendance(Attendance attendance);
        Task UpdateAttendance(Attendance attendance);
        Task DeleteAttendance(int id);
        Task<IEnumerable<Attendance>> GetAttendancesByStudentId(int studentId);
        Task<IEnumerable<Attendance>> GetAttendancesByCourseId(int courseId);
        Task<IEnumerable<Attendance>> GetAttendancesByDateRange(DateTime startDate, DateTime endDate);
    }
}