using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apuestas.DOMAIN.Core.Entities;
using Apuestas.DOMAIN.Infrastructure.Data;

namespace Apuestas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly ApuestasV2Context _context;

        public UsuarioRolController(ApuestasV2Context context)
        {
            _context = context;
        }

        // GET: api/UsuarioRol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> GetUsuarioRol()
        {
          if (_context.UsuarioRol == null)
          {
              return NotFound();
          }
            return await _context.UsuarioRol.ToListAsync();
        }

        // GET: api/UsuarioRol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> GetUsuarioRol(int id)
        {
          if (_context.UsuarioRol == null)
          {
              return NotFound();
          }
            var usuarioRol = await _context.UsuarioRol.FindAsync(id);

            if (usuarioRol == null)
            {
                return NotFound();
            }

            return usuarioRol;
        }

        // PUT: api/UsuarioRol/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRol(int id, UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRolExists(id))
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

        // POST: api/UsuarioRol
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> PostUsuarioRol(UsuarioRol usuarioRol)
        {
          if (_context.UsuarioRol == null)
          {
              return Problem("Entity set 'ApuestasV2Context.UsuarioRol'  is null.");
          }
            _context.UsuarioRol.Add(usuarioRol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioRolExists(usuarioRol.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioRol", new { id = usuarioRol.Id }, usuarioRol);
        }

        // DELETE: api/UsuarioRol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioRol(int id)
        {
            if (_context.UsuarioRol == null)
            {
                return NotFound();
            }
            var usuarioRol = await _context.UsuarioRol.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            _context.UsuarioRol.Remove(usuarioRol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioRolExists(int id)
        {
            return (_context.UsuarioRol?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
