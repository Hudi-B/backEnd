namespace productAPI
{
    public class DTOs
    {
        public record ProductDTO(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);

    }
}
