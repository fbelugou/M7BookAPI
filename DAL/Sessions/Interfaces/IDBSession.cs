using System.Data;

namespace DAL.Sessions.Interfaces;

internal interface IDBSession : IDisposable
{
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; set; }
}
