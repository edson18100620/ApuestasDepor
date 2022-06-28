using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{

    public class PartidoRepository : IPartidoRepository
    {
        private readonly ApuestasV2Context _context;
        public PartidoRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Partido>> GetPartidos()
        {
            //var data = new ApuestasV2Context();
            return await _context.Partido.ToListAsync();
        }

        public async Task<Partido> GetPartidoById(int id)
        {
            //var data = new ApuestasV2Context();
            var partido = await _context.Partido.FindAsync(id);
            if (partido == null)
                throw new Exception("Partido not found");
            return partido;
            //return await _context.Partido.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Partido partido)
        {
            //var data = new ApuestasV2Context();
            await _context.Partido.AddAsync(partido);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Partido partido)
        {
            _context.Partido.Update(partido);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var partido = await _context.Partido.FindAsync(id);
            if (partido == null)
                return false;
            _context.Partido.Remove(partido);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }
    }






}
