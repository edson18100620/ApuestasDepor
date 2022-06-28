using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApuestasDepor.DOMAIN.Core.DTOs;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisRepository _paisRepository;
        private readonly IMapper _mapper;

        public PaisController(IPaisRepository paisRepository, IMapper mapper)
        {
            _paisRepository = paisRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var pais = await _paisRepository.GetPais();
            var paisList = _mapper.Map<List<PaisDTO>>(pais);
            return Ok(paisList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var pais = await _paisRepository.GetPaisById(id);
            return Ok(pais);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PaisPostDTO paisDTO)
        {
            var pais = _mapper.Map<Pais>(paisDTO);
            await _paisRepository.Insert(pais);
            return Ok(pais.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PaisDTO paisDTO)
        {
            if (paisDTO.Id == 0)
                return NotFound();
            var pais = _mapper.Map<Pais>(paisDTO);
            var result = await _paisRepository.Update(pais);
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
            return NoContent();
        }
    }
}
