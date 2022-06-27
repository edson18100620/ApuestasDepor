using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var categoria = await _categoriaRepository.GetCategoria();
            return Ok(categoria);
        } 
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var categoria = await _categoriaRepository.GetCategoriaById(id);
            return Ok(categoria);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Categoria categoria)
        {
            await _categoriaRepository.Insert(categoria);
            return Ok(categoria.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Categoria categoria)
        {
            bool result = await _categoriaRepository.Update(categoria);
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
            return Ok(id);
        }
    }
}
