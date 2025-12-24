using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Interfaces;

namespace WebAppCleanArch.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetAllAsync();
        }

        public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
        {
            return await _enrollmentRepository.GetByStudentIdAsync(studentId);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsByCourseIdAsync(int courseId)
        {
            return await _enrollmentRepository.GetByCourseIdAsync(courseId);
        }

        public async Task<bool> CreateEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.AddAsync(enrollment);
            return true;
        }

        public async Task<bool> UpdateEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.UpdateAsync(enrollment);
            return true;
        }

        public async Task<bool> DeleteEnrollmentAsync(int id)
        {
            await _enrollmentRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> IsStudentEnrolledInCourseAsync(int studentId, int courseId)
        {
            return await _enrollmentRepository.IsStudentEnrolledAsync(studentId, courseId);
        }
    }
}