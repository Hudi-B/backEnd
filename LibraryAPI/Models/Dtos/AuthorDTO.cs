namespace LibraryAPI.Models.Dtos
{
    public record AuthorDTO(Guid Id, string Name, DateTime Birthdate, string Nationality);
    public record CreateAuthorDTO(string Name, DateTime Birthdate, string Nationality);
    public record UpdateAuthorDTO(string Name, DateTime Birthdate, string Nationality);
}
