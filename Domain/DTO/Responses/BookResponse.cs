namespace Domain.DTO.Responses;

public class BookResponse
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
        
}