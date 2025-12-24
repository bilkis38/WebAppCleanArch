using Microsoft.EntityFrameworkCore;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Interfaces;
using WebAppCleanArch.Infrastructure.Data;

namespace WebAppCleanArch.Infrastructure.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .OrderByDescending(a => a.AttendanceDate)
                .ToListAsync();
        }

        public async Task<Attendance?> GetByIdAsync(int id)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Attendance> AddAsync(Attendance attendance)
        {
            await _context.Attendances.AddAsync(attendance);
            await _context.SaveChangesAsync();
            return attendance;
        }

        public async Task UpdateAsync(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Attendance>> GetByStudentIdAsync(int studentId)
        {
            return await _context.Attendances
                .Where(a => a.StudentId == studentId)
                .Include(a => a.Course)
                .OrderByDescending(a => a.AttendanceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Attendances
                .Where(a => a.CourseId == courseId)
                .Include(a => a.Student)
                .OrderByDescending(a => a.AttendanceDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Attendance>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Attendances
                .Where(a => a.AttendanceDate >= startDate && a.AttendanceDate <= endDate)
                .Include(a => a.Student)
                .Include(a => a.Course)
                .OrderByDescending(a => a.AttendanceDate)
                .ToListAsync();
        }
    }
}
