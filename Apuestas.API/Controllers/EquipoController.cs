using ApuestasDepor.DOMAIN.Core.DTOs;
using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquiposRepository _equiposRepository;
        private readonly IMapper _mapper;
        public EquipoController(IEquiposRepository equipoRepository, IMapper mapper)
        {
            _equiposRepository = equipoRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var equipos = await _equiposRepository.GetEquipos();
            var equiposList = _mapper.Map<List<EquiposDTO>>(equipos);
            return Ok(equiposList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var equipos = await _equiposRepository.GetEquiposById(id);
            return Ok(equipos);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] EquiposPostDTO equiposDTO)
        {
            var equipos = _mapper.Map<Equipos>(equiposDTO);
            await _equiposRepository.Insert(equipos);
            return Ok(equipos.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] EquiposDTO equiposDTO)
        {
            if (equiposDTO.Id == 0)
                return NotFound();
            var equipos = _mapper.Map<Equipos>(equiposDTO);
            var result = await _equiposRepository.Update(equipos);
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
            return NoContent();
        }
    }
}
