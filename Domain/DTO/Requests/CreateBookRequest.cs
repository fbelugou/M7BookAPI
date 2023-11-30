using FluentValidation;

namespace Domain;

/// <summary>
/// Create book request Data Transfer Object
/// </summary>
public class CreateBookRequest
{
    /// <summary>
    /// Book title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Unique identifier of the author
    /// </summary>
    public int? AuthorId { get; set; }

    /// <summary>
    /// ISBN of the book
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// Short description of the book
    /// </summary>
    public string Description { get; set; }
}

/// <summary>
/// Validator for <see cref="CreateBookRequest"/>
/// </summary>
public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.AuthorId).NotEmpty();
        RuleFor(x => x.ISBN).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}