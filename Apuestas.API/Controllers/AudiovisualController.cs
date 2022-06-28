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
    public class AudiovisualController : ControllerBase
    {
        private readonly IAudioVisualRepository _audioVisualRepository;
        private readonly IMapper _mapper;
        public AudiovisualController(IAudioVisualRepository audioVisualRepository, IMapper mapper)
        {
            _audioVisualRepository = audioVisualRepository;
            _mapper = mapper;
        } 
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var audioVisual = await _audioVisualRepository.GetAudioVisual();
            var audioVisualList = _mapper.Map<List<AudioVisualDTO>>(audioVisual);
            return Ok(audioVisualList);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var audioVisual = await _audioVisualRepository.GetAudioVisualById(id);
            return Ok(audioVisual);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AudioVisualPostDTO audioVisualDTO)
        {
            var audioVisual = _mapper.Map<AudioVisual>(audioVisualDTO);
            await _audioVisualRepository.Insert(audioVisual);
            return Ok(audioVisual.Id);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AudioVisualDTO audioVisualDTO)
        {
            if (audioVisualDTO.Id == 0)
                return NotFound();
            var audioVisual = _mapper.Map<AudioVisual>(audioVisualDTO);
            var result = await _audioVisualRepository.Update(audioVisual);
            if (!result)
                return BadRequest();
            return Ok(audioVisual.Id);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteById([FromQuery] int id)
        {
            bool result = await _audioVisualRepository.Delete(id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
