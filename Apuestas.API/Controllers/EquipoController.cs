using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquiposRepository _equiposRepository;
        public EquipoController(IEquiposRepository equipoRepository)
        {
            _equiposRepository = equipoRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _equiposRepository.GetEquipos();
            return Ok(equipos);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var equipos = await _equiposRepository.GetEquiposById(id);
            return Ok(equipos);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Equipos equipos)
        {
            await _equiposRepository.Insert(equipos);
            return Ok(equipos);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Equipos equipos)
        {
            bool result = await _equiposRepository.Update(equipos);
            if (!result)
                return BadRequest();
            return Ok(equipos.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _equiposRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}
