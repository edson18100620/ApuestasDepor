using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuestaController : ControllerBase
    {
        private readonly IApuestaRepository _apuestaRepository;

        public ApuestaController(IApuestaRepository apuestaRepository)
        {
            _apuestaRepository = apuestaRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var apuestas = await _apuestaRepository.GetApuestas();
            return Ok(apuestas);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var apuesta = await _apuestaRepository.GetApuestaById(id);
            return Ok(apuesta);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Apuesta apuesta)
        {
            await _apuestaRepository.Insert(apuesta);
            return Ok(apuesta.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Apuesta apuesta)
        {
            bool result = await _apuestaRepository.Update(apuesta);
            if (!result)
                return BadRequest();
            return Ok(apuesta.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _apuestaRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }

    }
}
