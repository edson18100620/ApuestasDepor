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
    public class ProblemasController : ControllerBase
    {
        private readonly IProblemasRepository _problemasRepository;
        private readonly IMapper _mapper;
        public ProblemasController(IProblemasRepository problemasRepository, IMapper mapper)
        {
            _problemasRepository = problemasRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var problemas = await _problemasRepository.GetProblemas();
            var problemasList = _mapper.Map<List<ProblemasDTO>>(problemas);
            return Ok(problemasList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var problemas = await _problemasRepository.GetProblemasById(id);
            return Ok(problemas);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProblemasPostDTO problemasDTO)
        {
            var problemas = _mapper.Map<Problemas>(problemasDTO);
            await _problemasRepository.Insert(problemas);
            return Ok(problemas.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProblemasDTO problemasDTO)
        {
            if (problemasDTO.Id == 0)
                return NotFound();
            var problemas = _mapper.Map<Problemas>(problemasDTO);
            var result = await _problemasRepository.Update(problemas);
            if (!result)
                return BadRequest();
            return Ok(problemas.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _problemasRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

    }
}
