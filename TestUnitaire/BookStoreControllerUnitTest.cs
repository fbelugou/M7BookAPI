using BLL.Interfaces;
using Domain.DTO.Responses;
using Domain.Entities;
using M7BookAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitaire;
public class BookStoreControllerUnitTest
{

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async void GetBook_With_IdBelowZero_Should_Be_ReturnBadRequest(int id)
    {

        //Arrange
        IBookStoreService bookStoreService = Mock.Of<IBookStoreService>();
        BookStoreController bookStoreController = new BookStoreController(bookStoreService);
       
        //Act
        var result = await bookStoreController.GetBook(id);

        //Assert
        Assert.NotNull(result);
        Assert.NotNull(result as BadRequestResult);
    }

    [Fact]
    public async void GetBook_With_AnyIdAndServiceNotFoundBook_Should_Be_ReturnNotFound()
    {
        //Arrange
        IBookStoreService bookStoreService = Mock.Of<IBookStoreService>();

        Mock.Get(bookStoreService)
            .Setup(bookStoreService =>bookStoreService.GetBookByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(null as Book);

        BookStoreController bookStoreController = new BookStoreController(bookStoreService);
        //Act
        var result = await bookStoreController.GetBook(1);

        //Assert
        Assert.NotNull(result);
        Assert.NotNull(result as NotFoundResult);
    }


    [Fact]
    public async void GetBook_With_AnyIdAndServiceFoundBook_Should_Be_ReturnBookResponse()
    {
        //Arrange
        IBookStoreService bookStoreService = Mock.Of<IBookStoreService>();
        Mock.Get(bookStoreService)
            .Setup(bookStoreService => bookStoreService.GetBookByIdAsync(1))
            .ReturnsAsync(new Book() { Id = 1});

        BookStoreController bookStoreController = new BookStoreController(bookStoreService);
        //Act
        var result = await bookStoreController.GetBook(1);

        //Assert
        Assert.NotNull(result as OkObjectResult); //SatutsCode = 200
        var bookResponse = (result as OkObjectResult).Value as BookResponse;
        Assert.NotNull(bookResponse); //BookResponse not null
        Assert.Equal(1, bookResponse.Id); //BookResponse.Id = 1
    }

}
