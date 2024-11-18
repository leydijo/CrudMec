using CrudMec.Application.Dtos;
using CrudMec.Domain.Entities;

namespace CrudMec.Application.Interfaces
{
    public interface IMatterService
    {
        Task<Matter> GetById(int id);
        Task<IEnumerable<Matter>> GetAll();
        Task Add(Matter entity);
        Task Update(Matter entity);
        Task Delete(int id);

        Task<List<Student>> GetStudentsByMatters(List<int> matterIds);
    }
}
