using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using ApuestasDepor.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class ApuestaRepository : IApuestaRepository
    {
        private readonly ApuestasV2Context _context;
        public ApuestaRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Apuesta>> GetApuestas()
        {
            //var data = new ApuestasV2Context();
            return await _context.Apuesta.ToListAsync();
        }

        public async Task<Apuesta> GetApuestaById(int id)
        {
            //var data = new ApuestasV2Context();
            var apuesta = await _context.Apuesta.FindAsync(id);
            if (apuesta == null)
                throw new Exception("Apuesta not found");
            return apuesta;
            //return await _context.Apuesta.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Apuesta apuesta)
        {
            //var data = new ApuestasV2Context();
            await _context.Apuesta.AddAsync(apuesta);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Apuesta apuesta)
        {
            _context.Apuesta.Update(apuesta);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var apuesta = await _context.Apuesta.FindAsync(id);
            if (apuesta == null)
                return false;
            _context.Apuesta.Remove(apuesta);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }
    }

}
