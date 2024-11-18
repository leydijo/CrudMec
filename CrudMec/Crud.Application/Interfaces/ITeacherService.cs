using CrudMec.Application.Dtos;
using CrudMec.Domain.Entities;

namespace CrudMec.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> GetById(int id);
        Task<IEnumerable<Teacher>> GetAll();
        Task Add(Teacher entity);
        Task Update(Teacher entity);
        Task Delete(int id);
    }
}
