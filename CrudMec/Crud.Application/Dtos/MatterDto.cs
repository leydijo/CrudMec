using CrudMec.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CrudMec.Application.Dtos
{
    public class MatterDto
    {
        [Key]
        public int MateriaId { get; set; }
        public string? Name { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
