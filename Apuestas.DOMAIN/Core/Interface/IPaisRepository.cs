using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IPaisRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Pais>> GetPais();
        Task<Pais> GetPaisById(int id);
        Task<bool> Insert(Pais pais);
        Task<bool> Update(Pais pais);
    }
}