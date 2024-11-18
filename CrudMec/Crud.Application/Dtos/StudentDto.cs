using CrudMec.Domain.Entities;

namespace CrudMec.Application.Dtos
{
    public class StudentDto : Base
    {
        public string? profile { get; set; }
        public ICollection<Matter> Matters { get; set; } = new List<Matter>();
    }
}
