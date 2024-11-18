namespace CrudMec.Domain.Entities
{
    public class Student : Base
    {
        public string? profile { get; set; }
        public ICollection<Matter> Matters { get; set; } = new List<Matter>();
    }

}
