

using BLL.Interfaces;
using DAL;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace BLL.Implementations;
internal class BookStoreService : IBookStoreService
{

    private readonly IUOW _dbContext;

    public BookStoreService(IUOW dbContext)
    {
       _dbContext = dbContext;
    }

    //Books

    public Task<IEnumerable<Book>> GetBooksAsync()
    {
        return _dbContext.Books.GetAllAsync();
    }

    public Task<Book> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _dbContext.BeginTransaction();

        if(_dbContext.Authors.GetByIdAsync(book.Author.Id) is null)
        {
            _dbContext.Authors.AddAsync(book.Author);
        }

        var bookTask = _dbContext.Books.AddAsync(book);
        
        _dbContext.Commit();

        return await bookTask;
    }


    public Task<Book> UpdateBookAsync(Book book)
    {
        throw new NotImplementedException();
    }


    public Task<Book> DeleteBookAsync(Book book)
    {
        throw new NotImplementedException();
    }

    //Authors 

    public Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Author> GetAuthorByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Author> AddAuthorAsync(Author book)
    {
        throw new NotImplementedException();
    }


    public Task<Author> UpdateAuthorAsync(Author book)
    {
        throw new NotImplementedException();
    }


    public Task<Author> DeleteAuthorAsync(Author book)
    {
        throw new NotImplementedException();
    }
}
