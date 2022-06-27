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
    public class PromocionRepository : IPromocionRepository
    {
        private readonly ApuestasV2Context _context;
        public PromocionRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Promocion>> GetPromocion()
        {
            //var data = new ApuestasV2Context();
            return await _context.Promocion.ToListAsync();
        }

        public async Task<Promocion> GetPromocionById(int id)
        {
            //var data = new ApuestasV2Context();
            var promocion = await _context.Promocion.FindAsync(id);
            if (promocion == null)
                throw new Exception("Promocion not found");
            return promocion;
            //return await _context.Promocion.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Insert(Promocion promocion)
        {
            //var data = new ApuestasV2Context();
            await _context.Promocion.AddAsync(promocion);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Promocion promocion)
        {
            _context.Promocion.Update(promocion);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var promocion = await _context.Promocion.FindAsync(id);
            if (promocion == null)
                return false;
            _context.Promocion.Remove(promocion);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }

    }
}
