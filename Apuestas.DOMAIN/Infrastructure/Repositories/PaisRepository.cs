using ApuestasDepor.DOMAIN.Core.Entities;
using ApuestasDepor.DOMAIN.Core.Interface;
using ApuestasDepor.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Infrastructure.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApuestasV2Context _context;
        public PaisRepository(ApuestasV2Context context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pais>> GetPais()
        {

            return await _context.Pais.ToListAsync();
        }

        public async Task<Pais> GetPaisById(int id)
        {

            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
                throw new Exception("Pais not found");
            return pais;

        }

        public async Task<bool> Insert(Pais pais)
        {

            await _context.Pais.AddAsync(pais);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Update(Pais pais)
        {
            _context.Pais.Update(pais);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {

            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
                return false;
            _context.Pais.Remove(pais);
            int CountRows = await _context.SaveChangesAsync();
            return CountRows > 0;
        }
    }
}
