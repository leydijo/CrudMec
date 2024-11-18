using CrudMec.Domain.Entities;

namespace CrudMec.Domain.Interfaces
{
    public interface IRegistrationRepository 
    {
        Task RegisterUser(Registration registration);
    }
}
