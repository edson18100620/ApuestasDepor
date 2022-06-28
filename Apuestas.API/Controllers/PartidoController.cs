using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApuestasDepor.DOMAIN.Core.DTOs;

namespace Apuestas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        private readonly IPartidoRepository _partidoRepository;
        private readonly IMapper _mapper;
        public PartidoController(IPartidoRepository partidoRepository, IMapper mapper)
        {
            _partidoRepository = partidoRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var partido = await _partidoRepository.GetPartidos();
            var partidoList = _mapper.Map<List<PartidoDTO>>(partido);
            return Ok(partidoList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var partido = await _partidoRepository.GetPartidoById(id);
            return Ok(partido);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PartidoPostDTO partidoDTO)
        {
            var partido = _mapper.Map<Partido>(partidoDTO);
            await _partidoRepository.Insert(partido);
            return Ok(partido.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PartidoDTO partidoDTO)
        {
            if (partidoDTO.Id == 0)
                return NotFound();
            var audioVisual = _mapper.Map<Partido>(partidoDTO);
            var result = await _partidoRepository.Update(audioVisual);
            if (!result)
                return BadRequest();
            return Ok(audioVisual.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _partidoRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
