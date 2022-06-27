using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IEquiposRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Equipos>> GetEquipos();
        Task<Equipos> GetEquiposById(int id);
        Task<bool> Insert(Equipos equipos);
        Task<bool> Update(Equipos equipos);
    }
}