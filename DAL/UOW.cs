using DAL.Repositories.Implementations.MariaDB;
using DAL.Repositories.Implementations.SqlServer;
using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;
using System.Reflection;

namespace DAL;
internal class UOW : IUOW
{
    private readonly IDBSession _db;
    private readonly DBType _typeDB;
    private readonly Dictionary<Type, Type> _currentRepositories;

    private readonly Dictionary<Type, Type> RepositoriesMysql = new Dictionary<Type, Type>()
    {
        { typeof(IBookRepository), typeof(BookRepositoryMariaDB) },
        { typeof(IAuthorRepository), typeof(AuthorRepositoryMariaDB) }
    };
    private readonly Dictionary<Type, Type> RepositoriesSQLServer = new Dictionary<Type, Type>()
    {
        { typeof(IBookRepository), typeof(BookRepositorySqlServer) },
        { typeof(IAuthorRepository), typeof(AuthorRepositorySqlServer) }
    };

    public UOW(IDBSession dBSession, DBType typeDB)
    {
        _db = dBSession;
        _typeDB = typeDB;
        _currentRepositories = _typeDB switch
        {
            DBType.MariaDB => RepositoriesMysql,
            DBType.SQLServer => RepositoriesSQLServer,
            _ => throw new NotImplementedException()
        };
    }

    public IBookRepository Books => Activator.CreateInstance(_currentRepositories[typeof(IBookRepository)], _db) as IBookRepository;
    public IAuthorRepository Authors =>  Activator.CreateInstance(_currentRepositories[typeof(IAuthorRepository)], _db) as IAuthorRepository;

    public void BeginTransaction()
    {
        if (_db.Transaction is null)
        {
            _db.Transaction = _db.Connection.BeginTransaction();
        }
    }

    public void Commit()
    {
        if (_db.Transaction is not null)
        {
            _db.Transaction.Commit();
            _db.Transaction = null;
        }
    }

    public void Dispose()
    {
        if (_db.Transaction is not null)
        {
            _db.Transaction.Dispose();
            _db.Transaction = null;
        }
        _db.Connection.Dispose();
    }

    public void Rollback()
    {
        if (_db.Transaction is not null)
        {
            _db.Transaction.Rollback();
            _db.Transaction = null;
        }
    }
}
