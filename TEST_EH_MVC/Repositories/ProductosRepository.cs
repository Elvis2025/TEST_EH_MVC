using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using TEST_EH_MVC.DTOs;
using TEST_EH_MVC.Model;

namespace TEST_EH_MVC.Repositories
{
    public class ProductosRepository : BaseRepository, IProductosRepository
    {
        private readonly IDBConnection connection;
        private readonly IMapper mapper;

        public ProductosRepository(IDBConnection connection, IMapper mapper)
        {
            this.connection = connection;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Productos>> GetProducts()
        {
            try
            {
                Query = @$"SELECT 
                                ProNombre AS ProNombre,
                                ProDecripcion AS ProDecripcion,
                                ProPrecio AS ProPrecio,
                                ProCosto AS ProCosto ,
                                ProFechaCreacion AS ProFechaCreacion,
                                c.CatNombre AS CatNombre
                            FROM Productos p
                            INNER JOIN ProductosCategorias pc ON pc.ProID = p.ProID
                            INNER JOIN Categorias c ON c.CatID = pc.CatID";
               return await connection.DbConnection.GetAllAsync<Productos>();
            }
            catch (Exception)
            {
                throw;
            }
        }
         public async Task<Productos> GetProductsByID(int proId)
        {
            try
            {
               return await connection.DbConnection.GetAsync<Productos>(proId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteProduct(int proId)
        {
            try
            {
                Query = $@"DELETE ProductosCategorias WHERE ProID = {proId}
                           DELETE Productos WHERE ProID = {proId}";
                await connection.DbConnection.ExecuteAsync(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Productos>> GetProductsByDate(DateTime start,DateTime end)
        {
            try
            {
                Query = $"SELECT * FROM Productos WHERE ProFechaCreacion between '{start}' AND '{end}'";
                return await connection.DbConnection.QueryAsync<Productos>(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddProducts(ProductosDTO productosDTO)
        {
            using var dbConnection = connection.DbConnection;
            var transacction = dbConnection.BeginTransaction();
            try
            {
                var productos = mapper.Map<Productos>(productosDTO);
                var success = await dbConnection.InsertAsync(productos, transacction);
                if (success <= 0) throw new($"El producto {productos.ProID}-{productos.ProNombre} no pudo ser insertado");
                foreach (var item in productosDTO.CatIDs)
                {
                    Query = $"INSERT INTO ProductosCategorias (ProID, CatID) VALUES ('{success}', '{item}')";
                    var successCat = await dbConnection.ExecuteAsync(Query, transaction: transacction);
                }
                transacction.Commit();
            }
            catch (Exception)
            {
                transacction.Rollback();
                throw;
            }
        }
         public async Task<IEnumerable<Productos>> FindProductosByStatus(int status)
        {
            try
            {
                Query = $"SELECT * FROM Productos WHERE ProEstado = '{status}'";
                return await connection.DbConnection.QueryAsync<Productos>(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Productos>> FindProductosByCategoria(int statcatIDs)
        {
            try
            {
                Query = $"SELECT * FROM Productos WHERE CatID = '{statcatIDs}'";
                return await connection.DbConnection.QueryAsync<Productos>(Query);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
