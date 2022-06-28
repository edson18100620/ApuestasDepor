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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categoria = await _categoriaRepository.GetCategoria();
            var categoriaList = _mapper.Map<List<CategoriaDTO>>(categoria);
            return Ok(categoriaList);
        } 
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            return Ok(categoria);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoriaPostDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Insert(categoria);
            return Ok(categoria.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO.Id == 0)
                return NotFound();
            var categoria = _mapper.Map<Categoria>(categoriaDTO);
            var result = await _categoriaRepository.Update(categoria);
            if (!result)
                return BadRequest();
            return Ok(categoria.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _categoriaRepository.Delete(id);
            if (!result)
                return BadRequest(result);
            return NoContent();
        }
    }
}
