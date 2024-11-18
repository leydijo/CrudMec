using CrudMec.Domain.Entities;

namespace CrudMec.Domain.Interfaces
{
    public interface IMatterRepository : IRepository<Matter>
    {
        Task<int> CountMatterByTeacher(int teacherId);
        Task<Matter> UpdateMatterById(int matterId);
        Task<List<Student>> GetStudentsByMatters(List<int> matterIds);
    }
}
