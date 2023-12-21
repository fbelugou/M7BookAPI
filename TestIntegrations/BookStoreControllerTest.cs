using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TestIntegrations.Fixtures;

namespace TestIntegrations;
public class BookStoreControllerTest : AbstractIntegrationTest
{
    public BookStoreControllerTest(APIWebApplicationFactory fixture) : base(fixture)
    {

    }


    [Fact]
    public async Task GetAllBooks_ShouldBeRetrieve_3Books()
    {
        //Arrange
        List<Book> expectedBooks = new()
        {
            new Book { Id = 1, Title = "Les misérables", Description = "Les misérables est un roman de Victor Hugo publié en 1862", ISBN = "ISBN1", AuthorId = 1 },
            new Book { Id = 2, Title = "Notre dame de Paris", Description = "un roman historique publié en 1831", ISBN = "ISBN2", AuthorId = 1 },
            new Book { Id = 3, Title = "Alcools", Description = "Recueil de poèmes", ISBN = "ISBN2", AuthorId = 2 }
        };  

        Login();
        //Act
        var result = await _client.GetFromJsonAsync<List<Book>>("/api/bookstore/books");

        //Assert
        Assert.Equal(3, result.Count);

        for(int i = 0; i < result.Count; i++)
        {
            Assert.Equal(expectedBooks[i].Id, result[i].Id);
            Assert.Equal(expectedBooks[i].Title, result[i].Title);
            Assert.Equal(expectedBooks[i].Description, result[i].Description);
            Assert.Equal(expectedBooks[i].ISBN, result[i].ISBN);
            Assert.Equal(expectedBooks[i].AuthorId, result[i].AuthorId);
        }

        Logout();
    }


}
