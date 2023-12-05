using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;
using Domain.Entities;

namespace DAL.Repositories.Implementations.MariaDB;
internal class BookRepositoryMariaDB : IBookRepository
{
    private readonly IDBSession db;

    public BookRepositoryMariaDB(IDBSession dBSession)
    {
        db= dBSession;
    }

    public Task<Book> AddAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> UpdateAsync(Book entity)
    {
        throw new NotImplementedException();
    }
}
