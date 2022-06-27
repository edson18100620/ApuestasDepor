using ApuestasDepor.DOMAIN.Core.Entities;

namespace ApuestasDepor.DOMAIN.Core.Interface
{
    public interface ICategoriaRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Categoria>> GetCategoria();
        Task<Categoria> GetCategoriaById(int id);
        Task<bool> Insert(Categoria categoria);
        Task<bool> Update(Categoria categoria);
    }
}