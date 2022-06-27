using Apuestas.DOMAIN.Core.Entities;

namespace Apuestas.DOMAIN.Core.Interface
{
    public interface IRolRepository
    {
        Task<bool> Delete(int id);
        Task<Rol> GetRolById(int id);
        Task<IEnumerable<Rol>> GetRol();
        Task<bool> Insert(Rol rol);
        Task<bool> Update(Rol rol);
    }
}