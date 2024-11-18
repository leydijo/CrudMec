using CrudMec.Domain.Entities;

namespace CrudMec.Domain.Interfaces
{
    public interface ILoginRepository
    {
        string GenerateToken(Registration registration);
        Task<Registration> Autenticate(Login login);
    }
}
