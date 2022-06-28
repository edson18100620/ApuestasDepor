using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly ApuestasV2Context _context;
        public RolRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rol>> GetRol()
        {
            //var data = new ApuestasV2Context();
            return await _context.Rol.ToListAsync();
        }

        public async Task<Rol> GetRolById(int id)
        {
            //var data = new ApuestasV2Context();
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
                throw new Exception("Rol not found");
            return rol;
            //return await _context.Rol.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Rol rol)
        {
            //var data = new ApuestasV2Context();
            await _context.Rol.AddAsync(rol);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Rol rol)
        {
            _context.Rol.Update(rol);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
                return false;
            _context.Rol.Remove(rol);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }

    }
}
