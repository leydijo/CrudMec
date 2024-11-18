using CrudMec.Application.Dtos;
using CrudMec.Domain.Entities;

namespace CrudMec.Application.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetById(int id);
        Task<IEnumerable<Student>> GetAll();
        Task Add(Student entity);
        Task Update(Student entity);
        Task Delete(int id);
    }
}
