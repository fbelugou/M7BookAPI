

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

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.GetAllAsync();
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        return await _dbContext.Books.GetByIdAsync(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _dbContext.BeginTransaction();

        if(book.Author is not null && await _dbContext.Authors.GetByIdAsync(book.Author.Id) is null)
        {
            await _dbContext.Authors.AddAsync(book.Author);
        }

        var newBook = await _dbContext.Books.AddAsync(book);
        
        _dbContext.Commit();

        return newBook;
    }


    public async Task<Book> UpdateBookAsync(Book book)
    {
       return await _dbContext.Books.UpdateAsync(book);
    }


    public async Task<bool> DeleteBookAsync(int id)
    {
        return await _dbContext.Books.DeleteAsync(id);
    }

    //Authors 

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _dbContext.Authors.GetAllAsync();
    }

    public async Task<Author> GetAuthorByIdAsync(int id)
    {
        return await _dbContext.Authors.GetByIdAsync(id);
    }

    public async Task<Author> AddAuthorAsync(Author author)
    {
        return await _dbContext.Authors.AddAsync(author);
    }


    public async Task<Author> UpdateAuthorAsync(Author author)
    {
        return await _dbContext.Authors.UpdateAsync(author);
    }


    public async Task<bool> DeleteAuthorAsync(int id)
    {
        return await _dbContext.Authors.DeleteAsync(id);
    }
}
