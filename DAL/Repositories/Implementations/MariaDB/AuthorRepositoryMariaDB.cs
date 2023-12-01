using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;
using Domain.Entities;

namespace DAL.Repositories.Implementations.MariaDB;
internal class AuthorRepositoryMariaDB : IAuthorRepository
{

    private readonly IDBSession db;

    public AuthorRepositoryMariaDB(IDBSession dBSession)
    {
        db = dBSession;
    }

    public Task<Author> AddAsync(Author entity)
    {
        throw new NotImplementedException();
    }

    public Task<Author> DeleteAsync(Author entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Author>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Author> UpdateAsync(Author entity)
    {
        throw new NotImplementedException();
    }
}
