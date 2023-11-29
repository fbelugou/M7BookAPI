namespace Domain.Entities;
public class Author: IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Bio { get; set; }

    public IEnumerable<Book> Books { get; set; } = new List<Book>();

}
