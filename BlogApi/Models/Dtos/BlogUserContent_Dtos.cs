namespace BlogApi.Models.Dtos
{
    public record BlogUserContentDto(Guid Id, string Title, string Content, Guid UserId, DateTime Created);
    public record CreateBlogUserContentDto(string Content, string Title, Guid blogUserId);
    public record UpdateBlogUserContentDto(string Content, string Title);
}

