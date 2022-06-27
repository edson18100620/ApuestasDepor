using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;

        public PaisController(IPaisRepository paisRepository)
        {
            _paisRepository = paisRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var pais = await _paisRepository.GetPais();
            return Ok(pais);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var pais = await _paisRepository.GetPaisById(id);
            return Ok(pais);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Pais pais)
        {
            await _paisRepository.Insert(pais);
            return Ok(pais.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Pais pais)
        {
            bool result = await _paisRepository.Update(pais);
            if (!result)
                return BadRequest();
            return Ok(pais.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _paisRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}
