namespace LibraryAPIv2.Models.Dtos
{
    public record AuthorDTO(Guid Id, string Name, string Gender, Guid NationalityId);
    public record CreateAuthorDTO(string Name, string Gender, Guid NationalityId);
    public record UpdateAuthorDTO(string Name, string Gender, Guid NationalityId);
}
