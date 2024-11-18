using CrudMec.Domain.Entities;

namespace CrudMec.Application.Dtos
{
    public class TeacherDto : Base
    {
        public ICollection<Matter> Matters { get; set; } = new List<Matter>();
    }
}
