using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRolRepository 
    {
        private readonly ApuestasV2Context _context;
        //public UsuarioRolRepository(ApuestasV2Context context)
        //{
        //    _context = context;
        //}
        //public async Task<IEnumerable<UsuarioRol>> GetUsuarioRol()
        //{
        //    //var data = new ApuestasV2Context();
        //    return await _context.UsuarioRol.ToListAsync();
        //}

        //public async Task<UsuarioRol> GetUsuarioRolById(int id)
        //{
        //    //var data = new ApuestasV2Context();
        //    var usuariorol = await _context.UsuarioRol.FindAsync(id);
        //    if (usuariorol == null)
        //        throw new Exception("UsuarioRol not found");
        //    return usuariorol;
        //    //return await _context.UsuarioRol.FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task<bool> Insert(UsuarioRol usuariorol)
        //{
        //    //var data = new ApuestasV2Context();
        //    await _context.UsuarioRol.AddAsync(usuariorol);
        //    int countRows = await _context.SaveChangesAsync();
        //    return countRows > 0;
        //}

        //public async Task<bool> Update(UsuarioRol usuariorol)
        //{
        //    _context.UsuarioRol.Update(usuariorol);
        //    int countRows = await _context.SaveChangesAsync();
        //    return countRows > 0;
        //}

        //public async Task<bool> Delete(int id)
        //{

        //    var usuariorol = await _context.UsuarioRol.FindAsync(id);
        //    if (usuariorol == null)
        //        return false;
        //    _context.UsuarioRol.Remove(usuariorol);
        //    int CountRows = await _context.SaveChangesAsync();
        //    return CountRows > 0;
        //}

    }
}
