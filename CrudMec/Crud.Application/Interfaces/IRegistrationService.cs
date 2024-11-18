using CrudMec.Domain.Entities;

namespace CrudMec.Application.Interfaces
{
    public interface IRegistrationService
    {
       Task RegistrationAsync(Registration registration);
    }
}
