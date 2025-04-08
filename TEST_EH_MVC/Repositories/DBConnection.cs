using System.Data;
using Microsoft.Data.SqlClient;

namespace TEST_EH_MVC.Repositories;

public class DBConnection : IDBConnection
{
    private readonly string _connectionString;
    private SqlConnection? connection;

    public IDbConnection DbConnection
    {
        get
        {
            if (connection is null) connection = new SqlConnection(_connectionString);
             
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }
    }

    public DBConnection(IConfiguration configuration) => _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    
}
