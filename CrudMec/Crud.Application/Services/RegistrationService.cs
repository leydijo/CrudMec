using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;

namespace CrudMec.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepository _registration;

        public RegistrationService(IRegistrationRepository registration)
        {
            _registration = registration;
        }

        public  async Task RegistrationAsync(Registration registration)
        {
            await _registration.RegisterUser(registration);
        }
    }
}
