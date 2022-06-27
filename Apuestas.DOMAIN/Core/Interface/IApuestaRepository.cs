using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IApuestaRepository
    {
        Task<bool> Delete(int id);
        Task<Apuesta> GetApuestaById(int id);
        Task<IEnumerable<Apuesta>> GetApuestas();
        Task<bool> Insert(Apuesta apuesta);
        Task<bool> Update(Apuesta apuesta);
    }
}