using Domain.Entities;

namespace BLL.Interfaces;
public interface IBookStoreService
{
    //Books

    /// <summary>
    /// Add the book and the author if not exist to the database
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    Task<Book> AddBookAsync(Book book);
    Task<Book> UpdateBookAsync(Book book);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> GetBookByIdAsync(int id);
    Task<bool> DeleteBookAsync(int book);

    //Authors
    Task<Author> AddAuthorAsync(Author author);
    Task<bool> DeleteAuthorAsync(int authorId);
    Task<Author> GetAuthorByIdAsync(int id);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> UpdateAuthorAsync(Author author);



}