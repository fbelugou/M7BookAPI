using BLL.Implementations;
using DAL;
using DAL.Repositories.Interfaces;
using Domain.Entities;
using Moq;

namespace TestUnitaire;

public class BookStoreServiceUnitTest
{
    [Fact]
    public async void AddBookAsync_With_BookAndAuthor_Should_Be_ReturnBook()
    {

        //Arrange (Arrange les données d'entrée et isole la méthode à tester grace aux simulacres.)
        Book book = new Book
        {
            Title = "Test",
            Author = new Author
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test"
            }
        };

        IBookRepository bookRepository = Mock.Of<IBookRepository>();
        Mock.Get(bookRepository)
            .Setup(bookRepository => bookRepository.AddAsync(book))
            .ReturnsAsync(() =>
            {
                return new Book
                {
                    Id = 1, // Id généré par la base de données
                    Title = "Test",
                    AuthorId = 1
                };
            });

        //Simuler AuthorRepository
        IAuthorRepository authorRepository = Mock.Of<IAuthorRepository>();
        Mock.Get(authorRepository)
            .Setup(authorRepository => authorRepository.GetByIdAsync(book.Author.Id))
            .ReturnsAsync(book.Author);
        Mock.Get(authorRepository)
            .Setup(authorRepository => authorRepository.AddAsync(book.Author))
            .ReturnsAsync(book.Author);


        IUOW uow = Mock.Of<IUOW>();
        Mock.Get(uow)
            .Setup(uow => uow.Books)
            .Returns(bookRepository);
        Mock.Get(uow)
            .Setup(uow => uow.Authors)
            .Returns(authorRepository);

        BookStoreService bookStoreService = new BookStoreService(uow);

        //Act (Exécute la méthode à tester avec les données d'entrée.)

        var result = await bookStoreService.AddBookAsync(book);

        //Assert (Vérifie que la méthode à tester a produit les résultats attendus.)

        Assert.True(result.AuthorId == book.Author.Id);
        Assert.True(result.Title == book.Title);

    }
}