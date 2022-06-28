using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface IUsuarioRepository
    {
        Task<bool> Delete(int id);
        Task<Usuario> GetUsuarioById(int id);
        Task<IEnumerable<Usuario>> GetUsuario();
        Task<bool> Insert(Usuario usuario);
        Task<bool> Update(Usuario usuario);
    }
}