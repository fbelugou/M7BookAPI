using DAL.Repositories.Implementations.MariaDB;
using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;

namespace DAL;
internal class UOW : IUOW
{
    private readonly IDBSession db;

    public UOW(IDBSession dBSession)
    {
        db = dBSession;
    }

    public IBookRepository Books => new BookRepositoryMariaDB(db);

    public IAuthorRepository Authors => new AuthorRepositoryMariaDB(db);

    public void BeginTransaction()
    {
        if(db.Transaction is null)
        {
            db.Transaction = db.Connection.BeginTransaction();
        }
    }

    public void Commit()
    {
        if(db.Transaction is not null)
        {
            db.Transaction.Commit();
            db.Transaction = null;
        }
    }

    public void Dispose()
    {
        if(db.Transaction is not null)
        {
            db.Transaction.Dispose();
            db.Transaction = null;
        }
        db.Connection.Dispose();
    }

    public void Rollback()
    {
       if(db.Transaction is not null)
        {
            db.Transaction.Rollback();
            db.Transaction = null;
        }
    }
}
