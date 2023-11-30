namespace Domain.Entities;

/// <summary>
/// Book author
/// </summary>
public class Author : IEntity
{
    /// <summary>
    /// Unique identifier of the author
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// First name of the author
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of the author
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Books written by the author
    /// </summary>
    public IEnumerable<Book> Books { get; set; } = new List<Book>();

}
