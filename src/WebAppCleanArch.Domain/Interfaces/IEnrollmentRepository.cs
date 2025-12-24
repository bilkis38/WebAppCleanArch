using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAllAsync();
        Task<Enrollment?> GetByIdAsync(int id);
        Task<Enrollment> AddAsync(Enrollment enrollment);
        Task UpdateAsync(Enrollment enrollment);
        Task DeleteAsync(int id);
        Task<IEnumerable<Enrollment>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<Enrollment>> GetByCourseIdAsync(int courseId);
        Task<bool> IsStudentEnrolledAsync(int studentId, int courseId);
    }
}