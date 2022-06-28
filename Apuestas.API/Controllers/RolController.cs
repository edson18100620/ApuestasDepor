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
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;
        private readonly IMapper _mapper;
        public RolController(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rol = await _rolRepository.GetRol();
            var rolList = _mapper.Map<List<RolDTO>>(rol);
            return Ok(rolList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var rol = await _rolRepository.GetRolById(id);
            return Ok(rol);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] RolPostDTO rolDTO)
        {
            var rol = _mapper.Map<Rol>(rolDTO);
            await _rolRepository.Insert(rol);
            return Ok(rol.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] RolDTO rolDTO)
        {
            if (rolDTO.Id == 0)
                return NotFound();
            var rol = _mapper.Map<Rol>(rolDTO);
            var result = await _rolRepository.Update(rol);
            if (!result)
                return BadRequest();
            return Ok(rol.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _rolRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
