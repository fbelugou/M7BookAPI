using DAL.Repositories.Interfaces;
using DAL.Sessions.Interfaces;
using Dapper;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Implementations.SqlServer;
internal class BookRepositorySqlServer : IBookRepository
{
    private readonly IDBSession _dbSession;

    public BookRepositorySqlServer(IDBSession dBSession)
    {
        _dbSession = dBSession;
    }

    public async Task<Book> AddAsync(Book newBook)
    {
        string query = @"INSERT INTO Book (Title, ISBN, Description, AuthorId) 
                             OUTPUT INSERTED.ID
                             VALUES (@Title, @ISBN, @Description, @AuthorId)";
        var parameters = new
        {
            Title = newBook.Title,
            ISBN = newBook.ISBN,
            Description = newBook.Description,
            AuthorId = newBook.AuthorId
        };

        try
        {
            int insertedId = await _dbSession.Connection.ExecuteScalarAsync<int>(query, parameters, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            newBook.Id = insertedId;
            return newBook;
        }
        catch (SqlException)
        {
            throw new InsertEntityException(newBook);
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        string query = @"DELETE FROM Book WHERE Id=@Id";
        try
        {
            int nbDeleted = await _dbSession.Connection.ExecuteAsync(query, new { id = id }, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            return nbDeleted > 0;
        }
        catch (SqlException) //cas d'un auteur avec livre
        {
            throw new DeleteEntityException(default(Book), id);
        }
    }

    public async Task<IEnumerable<Book>> GetAllAsync(string? title)
    {
        string query = @"SELECT Id, Title, Description, ISBN, AuthorId FROM Book";
        object parameters = null;

        if (!String.IsNullOrEmpty(title))
        {
            query = query + " WHERE Title LIKE @Title";
            parameters = new { Title = $"%{title}%" };
        }
        var books = await _dbSession.Connection.QueryAsync<Book>(query, parameters, _dbSession.Transaction);
        return books;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await GetAllAsync(null);
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(int authorId)
    {
        string query = @"SELECT Id, Title, ISBN, Description, AuthorId
                             FROM Book
                             WHERE AuthorId=@AuthorId";

        var parameters = new { AuthorId = authorId };
        var books = await _dbSession.Connection.QueryAsync<Book>(query, parameters, _dbSession.Transaction);
        return books;
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        string query = @"SELECT b.Id, Title, Description, ISBN, AuthorId, a.Id, FirstName, LastName
                             FROM Book b JOIN Author a ON b.AuthorId = a.Id 
                             WHERE b.Id = @id";

        var parameters = new { Id = id };
        var book = await _dbSession.Connection.QueryAsync<Book, Author, Book>
              (query, (b, a) => { b.Author = a; return b; }, parameters, _dbSession.Transaction);
        return book.FirstOrDefault();
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        string query = @"UPDATE Book 
                            SET Title=@Title, Description=@Description, 
                            AuthorId=@AuthorId, ISBN=@ISBN 
                            WHERE Id=@Id";

        var parameters = new
        {
            Id = book.Id,
            Title = book.Title,
            ISBN = book.ISBN,
            Description = book.Description,
            AuthorId = book.AuthorId
        };

        try
        {
            int nbUpdated = await _dbSession.Connection.ExecuteAsync(query, parameters, _dbSession.Transaction); //Si une transaction existe, Dapper l'utilisera
            if (nbUpdated == 0) return null;
            return book;
        }
        catch (SqlException)
        {
            throw new UpdateEntityException(book);
        }
    }
}
