using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;

namespace CrudMec.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository) 
        {
            _loginRepository = loginRepository;
        }

        public async Task<Registration> Autenticate(Login login)
        {
           return await _loginRepository.Autenticate(login);
        }

        public  string GenerateToken(Registration registration)
        {
            return  _loginRepository.GenerateToken(registration);
        }
    }
}
