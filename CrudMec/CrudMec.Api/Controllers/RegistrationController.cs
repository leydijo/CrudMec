using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudMec.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService  _registration;

        public RegistrationController(IRegistrationService registration)
        {
            _registration = registration;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Registration registration)
        {
            try
            {
                await _registration.RegistrationAsync(registration);
                return Ok("Usuario registrado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
