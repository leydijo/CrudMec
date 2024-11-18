namespace CrudMec.Domain.Entities
{
    public class Teacher : Base
    {
        public ICollection<Matter> Matters { get; set; } = new List<Matter>();
    }
}
