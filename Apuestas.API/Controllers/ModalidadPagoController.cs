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
    public class ModalidadPagoController : ControllerBase
    {
        private readonly IModalidadPagoRepository _modalidadPagoRepository;
        private readonly IMapper _mapper;
        public ModalidadPagoController(IModalidadPagoRepository modalidadPagoRepository, IMapper mapper)
        {
            _modalidadPagoRepository = modalidadPagoRepository;
            _mapper = mapper;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var modalidadPago = await _modalidadPagoRepository.GetModalidadPago();
            var modalidadPagoList = _mapper.Map<List<ModalidadPagoDTO>>(modalidadPago);
            return Ok(modalidadPagoList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var modalidadPago = await _modalidadPagoRepository.GetModalidadPagoById(id);
            return Ok(modalidadPago);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ModalidadPagoPostDTO modalidadPagoDTO)
        {
            var modalidadPago = _mapper.Map<ModalidadPago>(modalidadPagoDTO);
            await _modalidadPagoRepository.Insert(modalidadPago);
            return Ok(modalidadPago.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ModalidadPagoDTO modalidadPagoDTO)
        {
            if (modalidadPagoDTO.Id == 0)
                return NotFound();
            var modalidadPago = _mapper.Map<ModalidadPago>(modalidadPagoDTO);
            var result = await _modalidadPagoRepository.Update(modalidadPago);
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
            return NoContent(); ;
        }
    }
}
