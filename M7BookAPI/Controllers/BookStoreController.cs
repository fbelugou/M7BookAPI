using Microsoft.AspNetCore.Mvc;

namespace M7BookAPI.Controllers;

/// <summary>
/// Control all Book Store 
/// </summary>
public class BookStoreController : APIBaseController
{

    /// <summary>
    /// Get all Books
    /// </summary>
    /// <returns>Returns all books on API</returns>
    public Task<IActionResult> GetAll()
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    /// <summary>
    /// Get a Book by unique identifier
    /// </summary>
    /// <param name="id">Unique identifier</param>
    /// <returns></returns>
    public Task<IActionResult> Get(int id)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    /// <summary>
    /// Add a new book on API
    /// </summary>
    /// <param name="book">Book to Add</param>
    /// <returns></returns>
    [HttpPost("books")]
    public Task<IActionResult> Post([FromBody] CreateBookRequest CreateBookRequest)
    {
        return Task.FromResult<IActionResult>(Ok());
    }

    /// <summary>
    /// Update a book on API
    /// </summary>
    /// <param name="book"></param>
    /// <returns></returns>
    [HttpPut("books/{idBook}")]

    public Task<IActionResult> Put([FromRoute] int idBook, [FromBody] ModifyBookRequest ModifyBookRequest)
    {
        return Task.FromResult<IActionResult>(Ok());
    }


}
