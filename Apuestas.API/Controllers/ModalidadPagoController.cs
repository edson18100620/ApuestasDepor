using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadPagoController : ControllerBase
    {
        private readonly IModalidadPagoRepository _modalidadPagoRepository;
        public ModalidadPagoController(IModalidadPagoRepository modalidadPagoRepository)
        {
            _modalidadPagoRepository = modalidadPagoRepository;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var modalidadPago = await _modalidadPagoRepository.GetModalidadPago();
            return Ok(modalidadPago);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var modalidadPago = await _modalidadPagoRepository.GetModalidadPagoById(id);
            return Ok(modalidadPago);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ModalidadPago modalidadPago)
        {
            await _modalidadPagoRepository.Insert(modalidadPago);
            return Ok(modalidadPago);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ModalidadPago modalidadPago)
        {
            bool result = await _modalidadPagoRepository.Update(modalidadPago);
            if (!result)
                return BadRequest();
            return Ok(modalidadPago.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _modalidadPagoRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}
