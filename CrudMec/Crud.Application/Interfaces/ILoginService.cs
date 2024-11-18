using CrudMec.Domain.Entities;

namespace CrudMec.Application.Interfaces
{
    public interface ILoginService
    {
        Task<Registration> Autenticate(Login login);

        string GenerateToken(Registration registration);
    }
}
