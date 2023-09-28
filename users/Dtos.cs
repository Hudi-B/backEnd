namespace users
{
    public class Dtos
    {
        public record UserDto(Guid Id, string Name, string Email, int Age, string Created);
        public record CreateUserDto(string Name, string Email, int Age);
        public record UpdateUserDto(string Name, string Email, int Age);
    }
}
