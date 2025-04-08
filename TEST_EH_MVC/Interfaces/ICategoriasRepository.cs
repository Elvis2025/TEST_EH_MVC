using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC
{
    public interface ICategoriasRepository
    {
        Task AddCategoria(Categorias categorias);
        Task<IEnumerable<Categorias>> GetCategorias();
        Task<IEnumerable<CategoriasDTO>> GetCategoriasByProIDs(List<int> proIds);
    }
}