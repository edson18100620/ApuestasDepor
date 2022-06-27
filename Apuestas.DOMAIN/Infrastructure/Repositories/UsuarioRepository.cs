using Apuestas.DOMAIN.Core.Entities;
using Apuestas.DOMAIN.Core.Interface;
using Apuestas.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apuestas.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApuestasV2Context _context;
        public UsuarioRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Usuario>> GetUsuario()
        {
            //var data = new ApuestasV2Context();
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            //var data = new ApuestasV2Context();
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                throw new Exception("Usuario not found");
            return usuario;
            //return await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            //var data = new ApuestasV2Context();
            await _context.Usuario.AddAsync(usuario);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
                return false;
            _context.Usuario.Remove(usuario);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }

    }
}
