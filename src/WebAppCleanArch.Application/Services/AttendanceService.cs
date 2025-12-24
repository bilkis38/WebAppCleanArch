using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Interfaces;

namespace WebAppCleanArch.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public async Task<IEnumerable<Attendance>> GetAllAttendances()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance?> GetAttendanceById(int id)
        {
            return await _attendanceRepository.GetByIdAsync(id);
        }

        public async Task AddAttendance(Attendance attendance)
        {
            await _attendanceRepository.AddAsync(attendance);
        }

        public async Task UpdateAttendance(Attendance attendance)
        {
            await _attendanceRepository.UpdateAsync(attendance);
        }

        public async Task DeleteAttendance(int id)
        {
            await _attendanceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByStudentId(int studentId)
        {
            return await _attendanceRepository.GetByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByCourseId(int courseId)
        {
            return await _attendanceRepository.GetByCourseIdAsync(courseId);
        }

        public async Task<IEnumerable<Attendance>> GetAttendancesByDateRange(DateTime startDate, DateTime endDate)
        {
            return await _attendanceRepository.GetByDateRangeAsync(startDate, endDate);
        }
    }
}