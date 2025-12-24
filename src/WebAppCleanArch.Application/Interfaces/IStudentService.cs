using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Application.Interfaces
{
    public interface IStudentService
    {
        // Synchronous methods
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
        
        // Asynchronous methods
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<Student>> GetAllStudentsWithCourseAsync();
        Task<Student?> GetStudentByIdAsync(int id);
        Task<Student?> GetStudentWithCourseAsync(int id);
        Task<Student?> GetStudentWithDetailsAsync(int id);
        Task<bool> CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int id);
        Task<bool> RemoveStudentFromCourseAsync(int id);
    }
}