using CrudMec.Domain.Entities;
using CrudMec.Domain.Interfaces;
using CrudMec.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CrudMec.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IConfiguration _config;
        public LoginRepository(AppDbContext appDbContext, IConfiguration config)
        {
            _appDbContext = appDbContext;
            _config = config;
        }

        public string GenerateToken(Registration registration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, registration.Username),
                new Claim(ClaimTypes.Email, registration.Email),
                new Claim(ClaimTypes.Name, registration.fullName),
                new Claim(ClaimTypes.Role, registration.Role)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<Registration> Autenticate(Login login)
        {
            var user  = await _appDbContext.Registrations.SingleOrDefaultAsync(u =>
             u.Username == login.UserName );
            
            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(login.Password, user.Password)) return null!;

            return new Registration
            {
                Username = user.Username,
                fullName = user.fullName,
                Email = user.Email, 
                Role = user.Role 
            };
        }

    }
}
