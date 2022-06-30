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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var usuario = await _usuarioRepository.GetUsuario();
            var usuarioList = _mapper.Map<List<UsuarioDTO>>(usuario);
            return Ok(usuarioList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioById(id);
            return Ok(usuario);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UsuarioPostDTO usuarioDTO)
        {
            usuarioDTO.RolId = 4;
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.Insert(usuario);
            return Ok(usuario.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO.Id == 0)
                return NotFound();
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            var result = await _usuarioRepository.Update(usuario);
            if (!result)
                return BadRequest();
            return Ok(usuario.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _usuarioRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
