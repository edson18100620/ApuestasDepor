using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IModalidadPagoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<ModalidadPago>> GetModalidadPago();
        Task<ModalidadPago> GetModalidadPagoById(int id);
        Task<bool> Insert(ModalidadPago modalidadPago);
        Task<bool> Update(ModalidadPago modalidadPago);
    }
}