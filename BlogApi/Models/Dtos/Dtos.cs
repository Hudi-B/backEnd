namespace BlogApi.Models.Dtos
{
    public record BlogUserDto(Guid Id, string Username, string UserEmail,
        string Password, DateTime CreatedTime);
    public record CreateBlogUserDto(string Username, string UserEmail,
        string Password);
    public record UpdateBlogUserDto(string Username, string UserEmail,
        string Password);
}
