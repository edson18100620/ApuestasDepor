using ApuestasDepor.DOMAIN.Core.Entities;

namespace Apuestas.DOMAIN.Core.Interface
{
    public interface IPartidoRepository
    {
        Task<bool> Delete(int id);
        Task<Partido> GetPartidoById(int id);
        Task<IEnumerable<Partido>> GetPartidos();
        Task<bool> Insert(Partido partido);
        Task<bool> Update(Partido partido);
    }
}