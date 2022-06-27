using Apuestas.DOMAIN.Core.Entities;

namespace Apuestas.DOMAIN.Core.Interface
{
    public interface IUsuarioRolRepository
    {
        Task<bool> Delete(int id);
        Task<UsuarioRol> GetUsuarioRolById(int id);
        Task<IEnumerable<UsuarioRol>> GetUsuarioRol();
        Task<bool> Insert(UsuarioRol usuariorol);
        Task<bool> Update(UsuarioRol usuariorol);
    }
}