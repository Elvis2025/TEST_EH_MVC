using System.Data;

namespace TEST_EH_MVC
{
    public interface IDBConnection
    {
        IDbConnection DbConnection { get; }
    }
}