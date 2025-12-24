using WebAppCleanArch.Domain.Entities;

namespace WebAppCleanArch.Domain.Interfaces
{
    public interface IStudentRepository
    {
        // Synchronous methods
        List<Student> GetAll();
        Student? GetById(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        
        // Asynchronous methods
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<Student>> GetAllWithCourseAsync();
        Task<Student?> GetByIdAsync(int id);
        Task<Student?> GetWithCourseAsync(int id);
        Task<Student?> GetWithDetailsAsync(int id);
        Task<Student> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
    }
}