using DAL.Sessions.Interfaces;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL.Sessions.Implementations;
internal class DBSessionSqlServer: IDBSession, IDisposable
{
    public IDbConnection Connection { get; private set; }

    public IDbTransaction Transaction { get; set; }

    public DBSessionSqlServer(string connectionString)
    {
        Connection = new SqlConnection(connectionString);
        Connection.Open();
    }

    public void Dispose()
    {
        Connection?.Dispose();
    }
}
