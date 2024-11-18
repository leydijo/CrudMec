using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudMec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _teacherService.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            try
            {
                await _teacherService.Add(teacher);
                return Ok(teacher);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

