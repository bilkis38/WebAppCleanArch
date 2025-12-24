using WebAppCleanArch.Application.Interfaces;
using WebAppCleanArch.Domain.Entities;
using WebAppCleanArch.Domain.Interfaces;

namespace WebAppCleanArch.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // Synchronous methods
        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }

        // Asynchronous methods
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsWithCourseAsync()
        {
            return await _studentRepository.GetAllWithCourseAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student?> GetStudentWithCourseAsync(int id)
        {
            return await _studentRepository.GetWithCourseAsync(id);
        }

        public async Task<Student?> GetStudentWithDetailsAsync(int id)
        {
            return await _studentRepository.GetWithDetailsAsync(id);
        }

        public async Task<bool> CreateStudentAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
            return true;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return true;
        }

        public async Task<bool> RemoveStudentFromCourseAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return false;
            }

            student.CourseId = null;
            await _studentRepository.UpdateAsync(student);
            return true;
        }
    }
}