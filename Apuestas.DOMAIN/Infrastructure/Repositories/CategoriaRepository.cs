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
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApuestasV2Context _context;
        public CategoriaRepository(ApuestasV2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria> GetCategoriaById(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
                throw new Exception("Categoria not  found");
            return categoria;
        }

        public async Task<bool> Insert(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<bool> Update(Categoria categoria)
        {
            _context.Categoria.Update(categoria);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
                return false;
            _context.Remove(categoria);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

    }
}
