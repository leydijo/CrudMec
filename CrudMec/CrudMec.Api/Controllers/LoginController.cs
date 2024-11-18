using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudMec.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginservice;
        public LoginController(ILoginService loginservice)
        {
            _loginservice = loginservice;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user =  await _loginservice.Autenticate(login);
            if (user != null)
            {
                var token = _loginservice.GenerateToken(user);
                return Ok(new { Token = token, Role = user.Role });
            }
            if (user.Role != "estudiante")
                return Forbid("Acceso denegado.");

            return NotFound("Usuario no encontrado");
        }
    }
}
