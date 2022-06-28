using ApuestasDepor.DOMAIN.Core.DTOs;
using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuestaController : ControllerBase
    {
        private readonly IApuestaRepository _apuestaRepository;
        private readonly IMapper _mapper;

        public ApuestaController(IApuestaRepository apuestaRepository, IMapper mapper)
        {
            _apuestaRepository = apuestaRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var apuestas = await _apuestaRepository.GetApuestas();
            var apuestasList = _mapper.Map<List<ApuestaDTO>>(apuestas);
            return Ok(apuestasList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var apuesta = await _apuestaRepository.GetApuestaById(id);
            return Ok(apuesta);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ApuestaPostDTO apuestaDTO)
        {
            var apuestas = _mapper.Map<Apuesta>(apuestaDTO);
            await _apuestaRepository.Insert(apuestas);
            return Ok(apuestas.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ApuestaDTO apuestaDTO)
        {
            if (apuestaDTO.Id == 0)
                return NotFound();
            var apuesta = _mapper.Map<Apuesta>(apuestaDTO);
            var result = await _apuestaRepository.Update(apuesta);
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
            return NoContent();
        }

    }
}
