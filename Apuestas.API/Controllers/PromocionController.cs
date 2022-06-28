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
    public class PromocionController : ControllerBase
    {
        private readonly IPromocionRepository _promocionRepository;
        private readonly IMapper _mapper;
        public PromocionController(IPromocionRepository promocionRepository, IMapper mapper)
        {
            _promocionRepository = promocionRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var promocion = await _promocionRepository.GetPromocion();
            var promocionList = _mapper.Map<List<PromocionDTO>>(promocion);
            return Ok(promocionList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var promocion = await _promocionRepository.GetPromocionById(id);
            return Ok(promocion);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PromocionPostDTO promocionDTO)
        {
            var promocion = _mapper.Map<Promocion>(promocionDTO);
            await _promocionRepository.Insert(promocion);
            return Ok(promocion.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PromocionDTO promocionDTO)
        {
            if (promocionDTO.Id == 0)
                return NotFound();
            var promocion = _mapper.Map<Promocion>(promocionDTO);
            var result = await _promocionRepository.Update(promocion);
            if (!result)
                return BadRequest();
            return Ok(promocion.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _promocionRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
