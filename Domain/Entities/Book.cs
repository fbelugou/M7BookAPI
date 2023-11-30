namespace Domain.Entities;

/// <summary>
/// Represent a Book
/// </summary>
public class Book : IEntity
{
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ISBN of the book
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Book title
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Summary of the book
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ID of the author
        /// </summary>
        public int AuthorId { get; set; }
        
        /// <summary>
        /// Book author
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// Verifies if a book is equal to another object
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if the object is a Book and has the same Id.</returns>
        public override bool Equals(object obj)
        {
            Book other = obj as Book;
            return !(other is null) && (this.Id == other.Id) ;  
        }

        // When you override Equals, you should also override GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
}
