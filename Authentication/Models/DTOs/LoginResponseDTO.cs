namespace Authentication.Models.DTOs
{
    public class LoginResponseDTO
    {
        public RegisterResponseDTO Register { get; set; }
        public string Token { get; set; }
    }
}
