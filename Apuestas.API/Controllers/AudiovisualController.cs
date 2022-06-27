using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApuestasDepor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiovisualController : ControllerBase
    {
        private readonly IAudioVisualRepository _audioVisualRepository;
        public AudiovisualController(IAudioVisualRepository audioVisualRepository)
        {
            _audioVisualRepository = audioVisualRepository;
        } 
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var audioVisual = await _audioVisualRepository.GetAudioVisual();
            return Ok(audioVisual);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var audioVisual = await _audioVisualRepository.GetAudioVisualById(id);
            return Ok(audioVisual);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AudioVisual audioVisual)
        {
            await _audioVisualRepository.Insert(audioVisual);
            return Ok(audioVisual);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] AudioVisual audioVisual)
        {
            bool result = await _audioVisualRepository.Update(audioVisual);
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
            return Ok(id);
        }
    }
}
