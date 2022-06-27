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
    public class EquiposRepository : IEquiposRepository
    {
        private readonly ApuestasV2Context _context;
        public EquiposRepository(ApuestasV2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipos>> GetEquipos()
        {
            return await _context.Equipos.ToListAsync();
        }

        public async Task<Equipos> GetEquiposById(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);

            if (equipos == null)
                throw new Exception("Equipos not  found");
            return equipos;
        }

        public async Task<bool> Insert(Equipos equipos)
        {
            await _context.Equipos.AddAsync(equipos);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<bool> Update(Equipos equipos)
        {
            _context.Equipos.Update(equipos);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
        public async Task<bool> Delete(int id)
        {
            var equipos = await _context.Equipos.FindAsync(id);
            if (equipos == null)
                return false;
            _context.Remove(equipos);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
