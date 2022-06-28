using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apuestas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        private readonly ApuestasV2Context _context;

        public PartidoController(ApuestasV2Context context)
        {
            _context = context;
        }

        // GET: api/Partido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partido>>> GetPartido()
        {
          if (_context.Partido == null)
          {
              return NotFound();
          }
            return await _context.Partido.ToListAsync();
        }

        // GET: api/Partido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Partido>> GetPartido(int id)
        {
          if (_context.Partido == null)
          {
              return NotFound();
          }
            var partido = await _context.Partido.FindAsync(id);

            if (partido == null)
            {
                return NotFound();
            }

            return partido;
        }

        // PUT: api/Partido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartido(int id, Partido partido)
        {
            if (id != partido.Id)
            {
                return BadRequest();
            }

            _context.Entry(partido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Partido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Partido>> PostPartido(Partido partido)
        {
          if (_context.Partido == null)
          {
              return Problem("Entity set 'ApuestasV2Context.Partido'  is null.");
          }
            _context.Partido.Add(partido);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PartidoExists(partido.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPartido", new { id = partido.Id }, partido);
        }

        // DELETE: api/Partido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartido(int id)
        {
            if (_context.Partido == null)
            {
                return NotFound();
            }
            var partido = await _context.Partido.FindAsync(id);
            if (partido == null)
            {
                return NotFound();
            }

            _context.Partido.Remove(partido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidoExists(int id)
        {
            return (_context.Partido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
