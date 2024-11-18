namespace CrudMec.Domain.Entities
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        public string  Username { get; set; } = null;
        public string? fullName { get; set; } = null;
        public string Email { get; set; } = null;
        public string Password { get; set; } = null;
        public int PhoneNumber { get; set; }
        public string Role { get; set; } = null;

    }
}
