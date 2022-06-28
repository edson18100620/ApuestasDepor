using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class ProblemasRepository : IProblemasRepository
    {
        private readonly ApuestasV2Context _context;
        public ProblemasRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Problemas>> GetProblemas()
        {
            //var data = new ApuestasV2Context();
            return await _context.Problemas.ToListAsync();
        }

        public async Task<Problemas> GetProblemasById(int id)
        {
            //var data = new ApuestasV2Context();
            var problemas = await _context.Problemas.FindAsync(id);
            if (problemas == null)
                throw new Exception("Problemas not found");
            return problemas;
            //return await _context.Problemas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Problemas problemas)
        {
            //var data = new ApuestasV2Context();
            await _context.Problemas.AddAsync(problemas);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Problemas problemas)
        {
            _context.Problemas.Update(problemas);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var problemas = await _context.Problemas.FindAsync(id);
            if (problemas == null)
                return false;
            _context.Problemas.Remove(problemas);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }

    }
}
