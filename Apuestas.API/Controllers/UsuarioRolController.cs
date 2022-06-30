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
    public class UsuarioRolController : ControllerBase
    {
        //    private readonly IUsuarioRolRepository _usuarioRolRepository;
        //    private readonly IMapper _mapper;
        //    public UsuarioRolController(IUsuarioRolRepository usuarioRolRepository, IMapper mapper)
        //    {
        //        _usuarioRolRepository = usuarioRolRepository;
        //        _mapper = mapper;
        //    }
        //    [HttpGet("GetAll")]
        //    public async Task<IActionResult> GetAll()
        //    {
        //        var usuarioRol = await _usuarioRolRepository.GetUsuarioRol();
        //        var usuarioRolList = _mapper.Map<List<UsuarioRolDTO>>(usuarioRol);
        //        return Ok(usuarioRolList);
        //    }
        //    [HttpGet("GetById")]
        //    public async Task<IActionResult> GetById([FromQuery] int id)
        //    {
        //        var usuarioRol = await _usuarioRolRepository.GetUsuarioRolById(id);
        //        return Ok(usuarioRol);
        //    }
        //    [HttpPost("Create")]
        //    public async Task<IActionResult> Create([FromBody]  UsuarioRolPostDTO usuarioRolDTO)
        //    {
        //        var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDTO);
        //        await _usuarioRolRepository.Insert(usuarioRol);
        //        return Ok(usuarioRol.Id);
        //    }
        //    [HttpPut("Update")]
        //    public async Task<IActionResult> Update([FromBody] UsuarioRolDTO usuarioRolDTO)
        //    {
        //        if (usuarioRolDTO.Id == 0)
        //            return NotFound();
        //        var usuarioRol = _mapper.Map<UsuarioRol>(usuarioRolDTO);
        //        var result = await _usuarioRolRepository.Update(usuarioRol);
        //        if (!result)
        //            return BadRequest();
        //        return Ok(usuarioRol.Id);
        //    }
        //    [HttpDelete("Delete")]
        //    public async Task<IActionResult> DeleteById([FromQuery] int id)
        //    {
        //        bool result = await _usuarioRolRepository.Delete(id);
        //        if (!result)
        //            return BadRequest();
        //        return NoContent();
        //    }
    }
}
