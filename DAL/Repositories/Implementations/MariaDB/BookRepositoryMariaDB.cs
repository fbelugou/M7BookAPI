using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace DAL.Repositories.Implementations.MariaDB;
internal class BookRepositoryMariaDB : IBookRepository
{
    public Task<Book> AddAsync(Book entity)
    {
        throw new NotImplementedException();
    }

    public Task<Book> DeleteAsync(Book entity)
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
