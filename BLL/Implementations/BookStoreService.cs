

using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Entities;

namespace BLL.Implementations;
internal class BookStoreService : IBookStoreService
{

    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;

    public BookStoreService(IBookRepository bookRepository, IAuthorRepository authorRepository)
    {
        bookRepository = _bookRepository;
        authorRepository = _authorRepository;
    }

    //Books

    public Task<IEnumerable<Book>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Book> GetBookByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book> AddBookAsync(Book book)
    {
        throw new NotImplementedException();
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
