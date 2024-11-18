using System.ComponentModel.DataAnnotations;

namespace CrudMec.Domain.Entities
{
    public class Matter
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
