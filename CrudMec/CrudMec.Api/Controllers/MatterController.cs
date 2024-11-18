using CrudMec.Application.Interfaces;
using CrudMec.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CrudMec.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatterController : ControllerBase
    {
        private readonly IMatterService _matterService;

        public MatterController(IMatterService matter)
        {
            _matterService = matter; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var res = await _matterService.GetAll();
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Matter matter)
        {
            try
            {
                await _matterService.Add(matter);
                return Ok(matter);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Matter matter)
        {
            if (id != matter.MateriaId)
            {
                return BadRequest("ID de la materia no existe.");
            }

            try
            {
                await _matterService.Update(matter);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _matterService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("byMatters")]
        public async Task<IActionResult> GetMatterByStudent([FromQuery] List<int> matterId)
        {
            try
            {
                var res = await _matterService.GetStudentsByMatters(matterId);
                if (res == null)
                {
                    return NotFound("No se  encontro materias para los estudiantes");
                }
                return Ok(res);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}

