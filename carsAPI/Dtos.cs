namespace carsAPI
{
    public record CarDTO(Guid Id, string Model, string Description, DateTime CreatedTime);

    public record CreateCarDTO(string Model, string Description);
    public record UpdateCarDTO(string Model, string Description);
}
