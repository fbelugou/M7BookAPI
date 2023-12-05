using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using Domain.Exceptions;
namespace DAL.Repositories.Implementations.SqlServer;
internal class AuthorRepositorySqlServer : IAuthorRepository
{

    private readonly IDBSession _dbSession;

    public AuthorRepositorySqlServer(IDBSession dBSession)
    {
        _dbSession = dBSession;
    }

    public async Task<Author> AddAsync(Author author)
    {
        string query = @"INSERT INTO AUTHOR (FirstName, LastName)
                             OUTPUT INSERTED.Id
                             VALUES(@FirstName, @LastName)";
        var parameters = new
        {
            FirstName = author.FirstName,
            LastName = author.LastName,
        };

        try
        {
            int insertedId = await _dbSession.Connection.ExecuteScalarAsync<int>(query, parameters, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            author.Id = insertedId;
            return author;
        }
        catch (SqlException)
        {
            throw new InsertEntityException(author);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        string query = @"DELETE FROM Author WHERE Id=@id";
        try
        {
            int nbDeleted = await _dbSession.Connection.ExecuteAsync(query, new { id = id }, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            return nbDeleted > 0;
        }
        catch (SqlException) //par exemple : cas d'un auteur avec livre
        {
            throw new DeleteEntityException(default(Author), id);
        }
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
        string query = @"SELECT Id, LastName, FirstName FROM Author";
        IEnumerable<Author> authors = await _dbSession.Connection.QueryAsync<Author>(query, _dbSession.Transaction);
        return authors;
    }

    public async Task<Author> GetByIdAsync(int id)
    {
        string query = @"SELECT Id, LastName, FirstName FROM Author WHERE id = @id";
        var parameters = new { id = id };
        Author author = await _dbSession.Connection.QuerySingleOrDefaultAsync<Author>(query, parameters, _dbSession.Transaction);
        return author;
    }

    public async Task<Author> UpdateAsync(Author author)
    {
        string query = @"UPDATE AUTHOR
                             SET    FirstName=@FirstName, 
                                    LastName=@LastName
                             WHERE  Id=@Id";

        var parameters = new
        {
            Id = author.Id,
            FirstName = author.FirstName,
            LastName = author.LastName
        };

        try
        {
            int nbUpdated = await _dbSession.Connection.ExecuteAsync(query, parameters, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            if (nbUpdated == 0) return null;
            return author;
        }
        catch (SqlException)
        {
            throw new UpdateEntityException(author);
        }
    }
}
