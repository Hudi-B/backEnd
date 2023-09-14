namespace productAPI
{
    public class DTOs
    {
        public record ProductDTO(Guid Id, string ProductName, int ProductPrice, DateTimeOffset CreatedTime, DateTimeOffset ModifiedTime);

        public record CreateProductDTO(string ProductName, int ProductPrice);

        public record UpdateProductDTO(string ProductName, int ProductPrice);
    }
}
