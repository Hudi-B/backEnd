namespace LibraryAPI.Models.Dtos
{
    public record BookDTO(Guid Id, string Title, string Genre, DateTime PublicationDate, string Availability, Guid AuthorId);
    public record CreateBookDTO(string Title, string Genre, DateTime PublicationDate, string Availability, Guid AuthorId);
    public record UpdateBookDTO(string Title, string Genre, DateTime PublicationDate, string Availability, Guid AuthorId);
}
