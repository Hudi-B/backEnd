namespace LibraryAPIv2.Models.Dtos
{
    public record BookDTO(Guid Id, string Title, string Genre, DateOnly Pubdate, Guid AuthorId);
    public record CreateBookDTO(string Title, string Genre, DateOnly Pubdate, Guid AuthorId);
    public record UpdateBookDTO(string Title, string Genre, DateOnly Pubdate, Guid AuthorId);
}
