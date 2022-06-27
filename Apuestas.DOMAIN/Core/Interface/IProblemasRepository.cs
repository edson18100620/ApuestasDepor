using Apuestas.DOMAIN.Core.Entities;

namespace Apuestas.DOMAIN.Core.Interface
{
    public interface IProblemasRepository
    {
        Task<bool> Delete(int id);
        Task<Problemas> GetProblemasById(int id);
        Task<IEnumerable<Problemas>> GetProblemas();
        Task<bool> Insert(Problemas problemas);
        Task<bool> Update(Problemas problemas);
    }
}