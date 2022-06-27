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
    public class ModalidadPagoRepository : IModalidadPagoRepository
    {
        private readonly ApuestasV2Context _context;
        public ModalidadPagoRepository(ApuestasV2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModalidadPago>> GetModalidadPago()
        {
            return await _context.ModalidadPago.ToListAsync();
        }

        public async Task<ModalidadPago> GetModalidadPagoById(int id)
        {
            var modalidadPago = await _context.ModalidadPago.FindAsync(id);

            if (modalidadPago == null)
                throw new Exception("Modalidad de Pago not  found");
            return modalidadPago;
        }

        public async Task<bool> Insert(ModalidadPago modalidadPago)
        {
            await _context.ModalidadPago.AddAsync(modalidadPago);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
        public async Task<bool> Update(ModalidadPago modalidadPago)
        {
            _context.ModalidadPago.Update(modalidadPago);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }
        public async Task<bool> Delete(int id)
        {
            var modalidadPago = await _context.ModalidadPago.FindAsync(id);
            if (modalidadPago == null)
                return false;
            _context.Remove(modalidadPago);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }
}
