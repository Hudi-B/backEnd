namespace LibraryAPIv2.Models.Dtos
{
    public record NationalityDTO(Guid Id, string Nation);
    public record CreateNationalityDTO(string Nation);
    public record UpdateNationalityDTO(string Nation);
}
