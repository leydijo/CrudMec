using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;
using CrudMec.Infrastructure.Data;

namespace CrudMec.Infrastructure.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _appDbContext;
        public RegistrationRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
        }

        public async Task RegisterUser(Registration registration)
        {
            
            var hashed = BCrypt.Net.BCrypt.HashPassword(registration.Password);

            var user = new Registration
            {
                Username = registration.Username,
                fullName = registration.fullName,
                Email = registration.Email,
                Role = registration.Role,
                Password = hashed
            };

            _appDbContext.Registrations.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
