using DAL.Repositories.Interfaces;

namespace DAL;
public interface IUOW : IDisposable
{
    // Repositories
    IBookRepository Books { get; }

    IAuthorRepository Authors { get; }

    //Transactions
    /// <summary>
    /// Begin a transaction on the current connection
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Commit the current transaction
    /// </summary>
    void Commit();

    /// <summary>
    /// Rollback the current transaction
    /// </summary>
    void Rollback();

}
