using Dapper;
using Dapper.Contrib.Extensions;
using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.Repositories
{
    public class CategoriasRepository :BaseRepository, ICategoriasRepository
    {
        private readonly IDBConnection connection;

        public CategoriasRepository(IDBConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<Categorias>> GetCategorias()
        {
            try
            {
                Query = "SELECT * FROM Categorias";
                return await connection.DbConnection.GetAllAsync<Categorias>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<CategoriasDTO>> GetCategoriasByProIDs(List<int> proIds)
        {
            try
            {
                if (proIds == null || !proIds.Any())
                    return Enumerable.Empty<CategoriasDTO>();
                Query = @$"SELECT 
                                c.CatID,
                                pc.CatNombre,
                                c.ProID
                           FROM ProductosCategorias c
                           INNER JOIN Categorias pc ON pc.CatID = c.CatID
                           WHERE c.ProID IN @ProIDs";
                return await connection.DbConnection.QueryAsync<CategoriasDTO>(Query, new { ProIDs = proIds });
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task AddCategoria(Categorias categorias)
        {
                var transacction = connection.DbConnection.BeginTransaction();
            try
            {
             
                await connection.DbConnection.InsertAsync(categorias,transacction);
                transacction.Commit();
            }
            catch (Exception)
            {
                transacction.Rollback();
                throw;
            }
        }
    }
}
