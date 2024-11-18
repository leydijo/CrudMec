using CrudMec.Domain.Entities;

namespace CrudMec.Domain.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> getStudentById(int studentId);
    }
}
