using CrudMec.Domain.Entities;

namespace CrudMec.Application.Dtos
{
    public class ResgistrationDto
    {
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int MatterId { get; set; }
        public Student? Student { get; set; }
        public Matter? Matter { get; set; }
    }
}
