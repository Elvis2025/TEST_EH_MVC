using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC
{
    public interface IProductosRepository
    {
        Task AddProducts(ProductosDTO productos);
        Task DeleteProduct(int proId);
        Task<IEnumerable<Productos>> FindProductosByCategoria(int statcatIDs);
        Task<IEnumerable<Productos>> FindProductosByStatus(int status);
        Task<IEnumerable<Productos>> GetProducts();
        Task<IEnumerable<Productos>> GetProductsByDate(DateTime start, DateTime end);
        Task<Productos> GetProductsByID(int proId);
    }
}