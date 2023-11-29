namespace Domain.Entities;
public class Book : IEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Author Author { get; set; } = string.Empty;
}
